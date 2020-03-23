using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jumpForce = 20.0f;
	public float upIncrease = 10.0f;
	public bool showDebugRay = false;

	private bool isTouchingSomething;
	private Vector3 somethingDirection;
#pragma warning disable CS0108 // Element blendet vererbte Element aus; fehlendes 'new'-Schlüsselwort
	private Rigidbody rigidbody;
#pragma warning restore CS0108 // Element blendet vererbte Element aus; fehlendes 'new'-Schlüsselwort

	// Start is called before the first frame update
	void Start()
    {
		rigidbody = this.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		rigidbody.AddForce(Input.GetAxis("Horizontal") * 2, 0.0f, Input.GetAxis("Vertical") * 2);
		if (isTouchingSomething) {
			rigidbody.AddForce(somethingDirection * Input.GetAxis("Jump"));
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		isTouchingSomething = true;
	}
	private void OnCollisionExit(Collision collision)
	{
		isTouchingSomething = false;
	}
	private void OnCollisionStay(Collision collision)
	{
		Vector3 direction = (transform.position - collision.contacts[0].point);
		somethingDirection = new Vector3(direction.x * jumpForce, direction.y * jumpForce + upIncrease, direction.z * jumpForce);
		if (showDebugRay) {
			Debug.DrawRay(transform.position, somethingDirection, Color.red, 10);
			Debug.Log(somethingDirection);
		}
	}
}
