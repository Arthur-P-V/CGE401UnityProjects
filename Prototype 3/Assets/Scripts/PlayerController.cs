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

    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        playerAudio= GetComponent<AudioSource>();

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
        

        forceMode = ForceMode.Impulse;
        playerAnimator= GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();

            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }
}
