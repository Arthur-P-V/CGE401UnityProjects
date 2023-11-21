/*
 Arthur Peterson-Veatch
 Challenge 4
 SpawnManagerX
 A script to handle the spawning of enemies and powerups
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameManager gameManager;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int enemyGoalHits;
    public int playerGoalHits;
    public int waveCount = 1;
    public float enemySpeed = 10f;


    public GameObject player;

    void Start() {
        enemySpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            if (playerGoalHits == (waveCount - 1) && playerGoalHits != 0)
            {
                gameManager.gameOver = true;
            }
            SpawnEnemyWave(waveCount);
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            enemy.GetComponent<EnemyX>().speed = enemySpeed;
            enemy.GetComponent<EnemyX>().spawnManager = gameObject.GetComponent<SpawnManagerX>();
        }
        playerGoalHits = 0;
        enemyGoalHits = 0;
        waveCount++;
        ResetPlayerPosition(); // put player back at start
        enemySpeed += 2f;

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
