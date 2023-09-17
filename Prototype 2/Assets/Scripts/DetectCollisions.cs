/*
* Arthur Peterson-Veatch
* Assignment 2
* This script controls the detection of collisions
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{


    private DisplayScore displayScoreScript;

    void Start() {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }
    private void OnTriggerEnter(Collider other) {

        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
