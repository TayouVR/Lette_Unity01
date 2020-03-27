using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float health = 100;
	public float maxHeath = 100;
	public GameObject healthBar;
	public bool randomMovement;
	public Transform goal;
	private Image _healthBarFill;
	private Text _healthText;
	private NavMeshAgent _agent;
	private Rigidbody _rigidbody;

	// Start is called before the first frame update
	private void Start()
	{
		_rigidbody = this.GetComponent<Rigidbody>();
		_agent = GetComponent<NavMeshAgent>();
		_healthBarFill = healthBar.transform.GetChild(0).GetComponent<Image>();
		_healthText = healthBar.GetComponentInChildren<Text>();
		//if (healthUI == null) healthUI = GameObject.Find("healthValue").GetComponent<Text>();
	}

	public void SetHealthUi()
	{
		if (health >= maxHeath) health = 100;

		_healthText.text = $"{health:0.0}" + " / " + maxHeath;
		_healthBarFill.fillAmount = health / maxHeath;
	}

	private void Update()
	{
		SetHealthUi();
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		if (randomMovement) {
			_rigidbody.AddForce(UnityEngine.Random.value * 2 - 1, 0.0f, UnityEngine.Random.value * 2 - 1);
		} else {
			_agent.destination = goal.position; 
		}
		if (health <= 0) {
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<Projectile>() != null) {
			health -= (other.gameObject.GetComponent<Projectile>().GetDamage());
			Destroy(other.gameObject);
		}
	}
}
