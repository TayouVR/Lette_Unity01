using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float healthSpawnPercentage = 0.1f;
	public float powerUpSpawnPercentage = 0.1f;
	public float enemySpawnPercentage = 0.1f;

	public GameObject healthPrefab;
	public GameObject powerUpPrefab;
	public GameObject enemyPrefab;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.value * 100 < healthSpawnPercentage) {
			Instantiate(healthPrefab, new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10), Quaternion.identity);
		}
		if (Random.value * 100 < powerUpSpawnPercentage) {
			Instantiate(powerUpPrefab, new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10), Quaternion.identity);
		}
		if (Random.value * 100 < enemySpawnPercentage) {
			Instantiate(enemyPrefab, new Vector3(Random.value * 20 - 10, 5, Random.value * 20 - 10), Quaternion.identity);
		}
	}
}
