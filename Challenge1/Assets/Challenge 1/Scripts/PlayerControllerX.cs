/*
 * Arthur Peterson-Veatch
 * Challenge 1
 * Script to Manage player movement for challenge 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    private GameObject propeller;

    // Start is called before the first frame update
    void Start()
    {
        //get propeller as child
        propeller = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);

        //rotate propeller around the z axis
        propeller.transform.Rotate(Vector3.forward * rotationSpeed);
    }
}
