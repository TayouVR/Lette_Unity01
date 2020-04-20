using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {

	public float healthSpawnPercentage = 0.1f;
	public GameObject healthPrefab;
	
	public float powerUpSpawnPercentage = 0.1f;
	public GameObject powerUpPrefab;
	
	public float enemySpawnPercentage = 0.1f;
	public GameObject enemyPrefab;
	public int collectableAmount = 4;
	public GameObject collectablePrefab;

	private void Start() {
		for (int i = 0; i < collectableAmount; i++) {
			Instantiate(collectablePrefab, new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10), Quaternion.identity);
		}
	}

	// Update is called once per frame
    private void FixedUpdate()
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
