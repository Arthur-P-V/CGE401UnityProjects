/*
* Arthur Peterson-Veatch
* Assignment 2
* This script controls the management of animal spawns
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] prefabsToSpawn;

    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;
    public bool gameOver = false;

    public HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);

        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    void SpawnRandomPrefab() { 
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }

    IEnumerator SpawnRandomPrefabWithCoroutine() {
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver) {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(0.8f, 2.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }
}
