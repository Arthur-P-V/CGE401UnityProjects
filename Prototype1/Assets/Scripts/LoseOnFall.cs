/*
 * Arthur Peterson-Veatch
 * Prototype 1
 * Script to trigger loss in ScoreManager for prototype 1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseOnFall : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textBox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1) {
            ScoreManager.gameOver = true;
        }
    }
}
