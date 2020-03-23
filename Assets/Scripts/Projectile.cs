using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float damageMultiplier = 0.1f;
	float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	public float getDamage() {
		return damage;
	}

    // Update is called once per frame
    void Update()
    {
		damage = GetComponent<Rigidbody>().velocity.magnitude * damageMultiplier;
		if (GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0) || this.transform.position.y < -5) {
			Destroy(this.gameObject);
		}
    }
}
