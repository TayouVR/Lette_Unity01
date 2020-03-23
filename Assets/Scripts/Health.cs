using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	private int health = 40;
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

		setHealthUI();
	}

	public void setHealthUI() {
		if (health >= max_heath) health = 100;

		healthText.text = String.Format("{0:0.0}", health) + " / " + max_heath;
		healthBarFill.fillAmount = health / max_heath;
	}

	public void getDamage(int value) {
		health -= value;
		setHealthUI();
	}

	public void heal(int value)
	{
		health += value;
		setHealthUI();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<heal>() != null) {
			heal(other.GetComponent<heal>().healthValue);
			Destroy(other.gameObject);
		}
	}
}
