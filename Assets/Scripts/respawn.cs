using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public float respawnHeight = -5;
	public float heightToRespawnTo = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= respawnHeight) {
			transform.SetPositionAndRotation(new Vector3(transform.position.x > 20 ? 19 : transform.position.x, heightToRespawnTo, transform.position.z > 20 ? 19 : transform.position.z), transform.rotation);
		}
    }
}
