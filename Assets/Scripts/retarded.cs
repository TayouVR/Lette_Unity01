using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retarded : MonoBehaviour {

	public bool randomScale = true;
	public float multiplier_X = 1;
	public float multiplier_Y = 1;
	public float multiplier_Z = 1;
	public bool randomLightColor = true;
	public float multiplier_R = 1;
	public float multiplier_G = 1;
	public float multiplier_B = 1;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (randomScale) {
			this.transform.localScale = new Vector3(Random.value * multiplier_X, Random.value * multiplier_Y, Random.value * multiplier_Z);
		}
		if (randomLightColor) {
			this.GetComponentInChildren<Light>().color = new Vector4(Random.value * multiplier_R, Random.value * multiplier_G, Random.value * multiplier_B, 1.0f);
		}
    }
}
