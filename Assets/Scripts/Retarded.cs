using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Retarded : MonoBehaviour {

	public bool randomScale = false;
	public float multiplierX = 1;
	public float multiplierY = 1;
	public float multiplierZ = 1;
	public bool randomLightColor = false;
	public float multiplierR = 1;
	public float multiplierG = 1;
	public float multiplierB = 1;

	private Light _light;

	// Start is called before the first frame update
	void Start()
	{
		_light = this.GetComponentInChildren<Light>();
	}

    // Update is called once per frame
    void Update()
    {
		if (randomScale) {
			this.transform.localScale = new Vector3(Random.value * multiplierX, Random.value * multiplierY, Random.value * multiplierZ);
		}
		if (randomLightColor) {
			_light.color = new Vector4(Random.value * multiplierR, Random.value * multiplierG, Random.value * multiplierB, 1.0f);
		}
    }
}
