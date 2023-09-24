/*
Arthur Peterson-Veatch
Prototype 3 part 1
Code to manage spawning obstacles
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    private float startDelay = 2f;
    private float repeatRate = 1.5f;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

    }

    void SpawnObstacle() {

        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
