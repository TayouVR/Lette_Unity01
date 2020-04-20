using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	private int _health = 40;
	public float maxHeath = 100;
	public GameObject healthBar;
	private Image _healthBarFill;
	private Text _healthText;

	// Start is called before the first frame update
	void Start()
	{
		_healthBarFill = healthBar.transform.GetChild(0).GetComponent<Image>();
		_healthText = healthBar.GetComponentInChildren<Text>();
		//if (healthUI == null) healthUI = GameObject.Find("healthValue").GetComponent<Text>();

		SetHealthUi();
	}

	private void SetHealthUi() {
		if (_health >= maxHeath) _health = 100;

		_healthText.text = String.Format("{0:0.0}", _health) + " / " + maxHeath;
		_healthBarFill.fillAmount = _health / maxHeath;
	}

	public void GetDamage(int value) {
		_health -= value;
		SetHealthUi();
	}

	public void Heal(int value)
	{
		_health += value;
		SetHealthUi();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<heal>() != null) {
			Heal(other.GetComponent<heal>().healthValue);
			Destroy(other.gameObject);
		}
	}
}
