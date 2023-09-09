/*
 * Arthur Peterson-Veatch
 * Challenge 1
 * Script to Manage score accumulation for challenge 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    public static bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (!triggered && other.CompareTag("Player")) {
            ScoreManager.Score++;
        }
    }
}
