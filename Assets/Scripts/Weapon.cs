using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public Transform target;
	public Transform rotator;
	public Transform bulletSpawnpoint;
	public GameObject bulletPrefab;
	private GameObject _bulletClone;
	public float initialBulletForce = 10.0f;

	// Update is called once per frame
	void Update()
	{
		Vector3 mouse = Input.mousePosition;
		Ray castPoint = Camera.main.ScreenPointToRay(mouse);
		if (Physics.Raycast(castPoint, out var hit, Mathf.Infinity))
		{
			target.position = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
		} else {
			target.position = new Vector3(hit.point.x, rotator.position.y, hit.point.z);
		}
		rotator.transform.LookAt(target, Vector3.up);
		if (Input.GetButton("Fire1")) {
			_bulletClone = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
			_bulletClone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, initialBulletForce));
		}
	}
}
