using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject objectToGoToPointer; 
	public Transform target;
	public Transform rotator;
	public Transform bulletSpawnpoint;
	public GameObject bulletPrefab;
	GameObject BulletClone;
	public float initialBulletForce = 10.0f;

	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		Vector3 mouse = Input.mousePosition;
		Ray castPoint = Camera.main.ScreenPointToRay(mouse);
		RaycastHit hit;
		if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
		{
			target.position = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
		}
		rotator.transform.LookAt(target, Vector3.up);
		if (Input.GetButton("Fire1")) {
			BulletClone = Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
			BulletClone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, initialBulletForce));
		}
	}
}
