/*
 * Arthur Peterson-Veatch
 * Challenge 1
 * Script to Manage out of bounds player for challenge 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 80 || transform.position.y < -51) {
            ScoreManager.GameOver = true;
        }
    }
}
