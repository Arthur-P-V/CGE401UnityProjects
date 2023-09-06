/*
 * Arthur Peterson-Veatch
 * Prototype 1
 * Deprecated script to handle trigger entry behavior for prototype 1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerEnterTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    //set reference in the inspector
    public Text textBox;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("TriggerZone")) {
            ScoreManager.score++;
        }
    }
}
