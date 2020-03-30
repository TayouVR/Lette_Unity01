using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jumpForce = 20.0f;
	public float upIncrease = 10.0f;
	public bool showDebugRay;

	private bool _isTouchingSomething;
	private Vector3 _jumpDirection;
#pragma warning disable CS0108 // Element blendet vererbte Element aus; fehlendes 'new'-Schlüsselwort
	private Rigidbody _rigidbody;
#pragma warning restore CS0108 // Element blendet vererbte Element aus; fehlendes 'new'-Schlüsselwort

	// Start is called before the first frame update
	void Start()
    {
		_rigidbody = this.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		_rigidbody.AddForce(Input.GetAxis("Horizontal") * 2, 0.0f, Input.GetAxis("Vertical") * 2);
		if (_isTouchingSomething) {
			_rigidbody.AddForce(_jumpDirection * Input.GetAxis("Jump"));
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		_isTouchingSomething = true;
	}
	private void OnCollisionExit(Collision collision)
	{
		_isTouchingSomething = false;
	}
	private void OnCollisionStay(Collision collision)
	{
		Vector3 direction = (transform.position - collision.contacts[0].point);
		_jumpDirection = new Vector3(direction.x * jumpForce, direction.y * jumpForce + upIncrease, direction.z * jumpForce);
		if (showDebugRay) {
			Debug.DrawRay(transform.position, _jumpDirection, Color.red, 10);
			Debug.Log(_jumpDirection);
		}
	}
}
