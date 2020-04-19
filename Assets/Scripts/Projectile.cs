using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float damageMultiplier = 0.1f;
	private float _damage;
	private Rigidbody _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
	    _rigidbody = GetComponent<Rigidbody>();
    }

    public float GetDamage() {
		return _damage;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
		_damage = _rigidbody.velocity.magnitude * damageMultiplier;
		if (_rigidbody.velocity == new Vector3(0, 0, 0) || this.transform.position.y < -5) {
			Destroy(this.gameObject);
		}
    }
}
