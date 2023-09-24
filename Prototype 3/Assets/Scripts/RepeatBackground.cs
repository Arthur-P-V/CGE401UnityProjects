/*
Arthur Peterson-Veatch
Prototype 3 part 1
Code to manage background repeating
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPosition;

    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //save start position as vector 3
        startPosition = transform.position;

        //set repeatWidth to half of width of background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the background is farther to the left than repeatWidth, reset background
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
