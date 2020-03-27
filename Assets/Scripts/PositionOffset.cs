using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOffset : MonoBehaviour {

	public GameObject gameobject;
	public Vector3 offset;
	public bool keepOffset;

    // Start is called before the first frame update
    void Start()
    {
		gameobject.transform.position = offset;
	}

    // Update is called once per frame
    void Update()
    {
	    var position = this.transform.position;
		if (!keepOffset) {
			gameobject.transform.position = new Vector3(position.x, gameobject.transform.position.y, position.z);
		} else {
			gameobject.transform.position = new Vector3(this.transform.position.x + offset.x, position.y + offset.y, position.z + offset.z);
		}
    }
}
