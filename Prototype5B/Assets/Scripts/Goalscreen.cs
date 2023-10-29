/*
 Arthur Peterson-Veatch
 3d prototype
 This is a script to enable the win text
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goalscreen : MonoBehaviour
{
    public GameObject wintext;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish")) {
            wintext.SetActive(true);
        }
    }
}
