/*
* Arthur Peterson-Veatch
* Challenge 2
* This script controls the spawning of balls to shoot
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    public ScoreManager scoreManager;

    /*private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;*/

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        StartCoroutine(SpawnRandomBallWithCoroutine());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        int randomBall = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBall], spawnPos, ballPrefabs[randomBall].transform.rotation);
    }

    IEnumerator SpawnRandomBallWithCoroutine() {
        yield return  new WaitForSeconds(1f);

        while (!scoreManager.gameOver)
        {
            SpawnRandomBall();

            float randomDelay = Random.Range(3f, 3f);

            yield return new WaitForSeconds(randomDelay);
        }
           
    }

}
