/*
Arthur Peterson-Veatch
Prototype 3 part 1
Code to control the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpForce;
    public float gravityModifier;
    public ForceMode forceMode;

    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
        

        forceMode = ForceMode.Impulse;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("GameOver");
            gameOver = true;
        }
    }
}
