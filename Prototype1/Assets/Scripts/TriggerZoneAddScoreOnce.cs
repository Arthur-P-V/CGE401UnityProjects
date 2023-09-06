﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScoreOnce : MonoBehaviour
{

    private bool triggered = false;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !triggered) {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
