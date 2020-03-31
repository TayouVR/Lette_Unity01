using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public Transform rotator;
	public Transform bulletSpawnpoint;
	public GameObject bulletPrefab;
	private Vector3 _target;
	private GameObject _bulletClone;
	public float initialBulletForce = 10.0f;

	private void Start()
	{
		_target = new Vector3();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 mouse = Input.mousePosition;
		Debug.Log(Input.mousePosition.x - (Screen.width/2));
		Ray castPoint = Camera.main.ScreenPointToRay(mouse);
		if (Physics.Raycast(castPoint, out var hit, Mathf.Infinity))
		{
			_target = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
		} else {
			_target = new Vector3(rotator.position.x + (Input.mousePosition.x - (Screen.width/2)), rotator.position.y,rotator.position.z + (Input.mousePosition.y - (Screen.height/2)));
		}
		rotator.transform.LookAt(_target, Vector3.up);
		if (Input.GetButton("Fire1")) {
			_bulletClone = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
			_bulletClone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, initialBulletForce));
		}
	}
}
