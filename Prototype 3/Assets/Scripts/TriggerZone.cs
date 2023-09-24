/*
Arthur Peterson-Veatch
Prototype 3 part 1
Code to manage trigger zones for scoring
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    // Start is called before the first frame update
    private UIManager uIManager;

    private bool triggered = false;
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            uIManager.score++;
        }
    }


}
