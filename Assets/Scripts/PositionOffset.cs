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
		if (!keepOffset)	{
			gameobject.transform.position = new Vector3(this.transform.position.x, gameobject.transform.position.y, this.transform.position.z);
		} else {
			gameobject.transform.position = new Vector3(this.transform.position.x + offset.x, this.transform.position.y + offset.y, this.transform.position.z + offset.z);
		}
    }
}
