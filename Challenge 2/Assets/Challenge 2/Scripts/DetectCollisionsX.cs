﻿/*
* Arthur Peterson-Veatch
* Challenge 2
* This script controls the detection of collisions and increment of score
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    public ScoreManager scoreManager;

    void Start() { 
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        scoreManager.score++;

    }
}
