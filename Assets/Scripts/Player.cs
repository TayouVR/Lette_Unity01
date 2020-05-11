using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : Healthable {

	// Game Manager
	public GameManager gameManager;
	
	// health
	public float health = 40;
	public float maxHealth = 100;
	public GameObject healthBar;
	
	private Image _healthBarFill;
	private Text _healthText;
	
	
	// movement
	public float jumpForce = 20.0f;
	public float upIncrease = 10.0f;
	public bool showDebugRay;

	private bool _isTouchingSomething;
	private Vector3 _jumpDirection;
	private Rigidbody _rigidbody;

	// Start is called before the first frame update
	private void Start() {
		_healthBarFill = healthBar.transform.GetChild(0).GetComponent<Image>();
		_healthText = healthBar.GetComponentInChildren<Text>();
		//if (healthUI == null) healthUI = GameObject.Find("healthValue").GetComponent<Text>();
		_rigidbody = this.GetComponent<Rigidbody>();

		SetHealthUi();
	}

	public void SetHealthUi() {
		if (health >= maxHealth) health = maxHealth;

		_healthText.text = String.Format("{0:0.0}", health) + " / " + maxHealth;
		_healthBarFill.fillAmount = health / maxHealth;
	}

	public void GetDamage(float value) {
		health -= value;
		if (health <= 0) {
			gameManager.ToGameOver();
		} 
		SetHealthUi();
	}

	public void Heal(float value)
	{
		health += value;
		SetHealthUi();
	}

	// Update is called once per frame
	private void FixedUpdate() {
		_rigidbody.AddForce(Input.GetAxis("Horizontal") * 2, 0.0f, Input.GetAxis("Vertical") * 2);
		if (_isTouchingSomething) {
			_rigidbody.AddForce(_jumpDirection * Input.GetAxis("Jump"));
		}
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Pickup>() == null) return;
		switch (other.GetComponent<Pickup>().pickupType) {
			case PickupType.Health:
				if (health < maxHealth) {
					Heal(other.GetComponent<Pickup>().value);
					Destroy(other.gameObject);
				}
				break;
			case PickupType.PowerUp:
				break;
			case PickupType.Ammo:
				break;
			case PickupType.Collectable:
				gameManager.ItemsCollected++;
				Destroy(other.gameObject);
				break;
		}
	}
	private void OnCollisionExit(Collision collision) {
		_isTouchingSomething = false;
	}
	private void OnCollisionStay(Collision collision) {
		_isTouchingSomething = true;
		Vector3 direction = (transform.position - collision.contacts[0].point);
		_jumpDirection = new Vector3(direction.x * jumpForce, direction.y * jumpForce + upIncrease, direction.z * jumpForce);
		if (showDebugRay) {
			Debug.DrawRay(transform.position, _jumpDirection, Color.red, 10);
			Debug.Log(_jumpDirection);
		}
	}
}
