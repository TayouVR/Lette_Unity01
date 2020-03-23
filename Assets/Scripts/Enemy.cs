using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float health = 100;
	public float max_heath = 100;
	public GameObject healthBar;
	private Image healthBarFill;
	private Text healthText;

	// Start is called before the first frame update
	void Start()
	{
		healthBarFill = healthBar.transform.GetChild(0).GetComponent<Image>();
		healthText = healthBar.GetComponentInChildren<Text>();
		//if (healthUI == null) healthUI = GameObject.Find("healthValue").GetComponent<Text>();
	}

	public void setHealthUI()
	{
		if (health >= max_heath) health = 100;

		healthText.text = String.Format("{0:0.0}", health) + " / " + max_heath;
		healthBarFill.fillAmount = health / max_heath;
	}

	private void Update()
	{
		setHealthUI();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		this.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.value * 2 - 1, 0.0f, UnityEngine.Random.value * 2 - 1);
		if (health <= 0) {
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<Projectile>() != null) {
			health -= (other.gameObject.GetComponent<Projectile>().getDamage());
			Destroy(other.gameObject);
		}
	}
}
