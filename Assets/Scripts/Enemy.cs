using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Healthable {

	public float health = 100;
	public float maxHealth = 100;
	public GameObject healthBar;
	public bool randomMovement;
	public NavMeshAgent agent;
	private Image _healthBarFill;
	private Text _healthText;
	private Rigidbody _rigidbody;
	
	public Transform routeParent;
	private List<GameObject> route = new List<GameObject>();
	private int _patrolRouteIndex;

	private GameObject _currentGoal;

	// Start is called before the first frame update
	private void Start() {
		if (routeParent == null) {
			routeParent = GameObject.Find("path").transform;
		}
		foreach (Transform point in routeParent) {
			route.Add(point.gameObject);
		}
		_rigidbody = this.GetComponent<Rigidbody>();
		_healthBarFill = healthBar.transform.GetChild(0).GetComponent<Image>();
		_healthText = healthBar.GetComponentInChildren<Text>();
		if (healthBar == null) healthBar = GameObject.Find("healthValue");
		SetGoal(route[0]);
	}

	public void SetGoal(GameObject go) {
		_currentGoal = go;
		agent.SetDestination(go.transform.position);
	}

	private void SetHealthUi() {
		if (health >= maxHealth) health = 100;

		_healthText.text = $"{health:0.0}" + " / " + maxHealth;
		_healthBarFill.fillAmount = health / maxHealth;
	}

	private void Update() {
		SetHealthUi();
		agent.SetDestination(_currentGoal.transform.position);
		if (agent.remainingDistance < 1) {
			int nextIndex = _patrolRouteIndex == route.Count-1 ? 0 : _patrolRouteIndex+1;
			SetGoal(route[nextIndex]);
			_patrolRouteIndex = nextIndex;
		}
	}

	// Update is called once per frame
	private void FixedUpdate() {
		if (health <= 0) {
			Destroy(gameObject.transform.parent.gameObject);
		}
		if (randomMovement) {
			_rigidbody.AddForce(Random.value * 2 - 1, 0.0f, Random.value * 2 - 1);
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<Projectile>() != null) {
			health -= (other.gameObject.GetComponent<Projectile>().GetDamage());
			Destroy(other.gameObject);
		}
	}
}
