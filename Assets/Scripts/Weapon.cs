using UnityEngine;

public class Weapon : MonoBehaviour {
	public Transform rotator;
	public Transform bulletSpawnpoint;
	public GameObject bulletPrefab;
	private Vector3 _target;
	public float initialBulletForce = 10.0f;

	private void Start() {
		_target = new Vector3();
	}

	// Update is called once per frame
	void Update() {
		Vector3 mouse = Input.mousePosition;
		Ray castPoint = Camera.main.ScreenPointToRay(mouse);
		if (Physics.Raycast(castPoint, out var hit, Mathf.Infinity)) {
			_target = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
		} else {
			var position = rotator.position;
			_target = new Vector3(position.x + (mouse.x - Screen.width/2f), position.y,position.z + (mouse.y - Screen.height/2f));
		}
		rotator.transform.LookAt(_target, Vector3.up);
		if (Input.GetButton("Fire1")) {
			Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation)
				.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, initialBulletForce));
		}
	}
}
