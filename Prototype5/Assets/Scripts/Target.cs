﻿/*
	* Arthur Peterson-Veatch
	* Target.cs
	* Assignment 8
	* Script to define target behavior
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public int pointValue;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {

        if (gameManager.isGameActive) { 
            gameManager.UpdateScore(pointValue);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (!gameObject.CompareTag("Bad")) { 
            gameManager.GameOver();
        }
        
        Destroy(gameObject);
    }
}
