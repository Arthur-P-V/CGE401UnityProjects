/*
 Arthur Peterson-Veatch
 Challenge 3
 This is a script to manage player movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public int score;
    public Text scoreText;
    public bool won;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        scoreText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) { 
            scoreText.text = "Score: " + score;
        }
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        if (transform.position.y > 15) {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, 15, transform.position.z), transform.rotation);
            playerRb.velocity = Vector3.zero;
        }

        if (transform.position.y < 1) {
            playerRb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

        if (score >= 10) {
            gameOver = true;
            won = true;
        }

        if (gameOver && won) {
            scoreText.text = "You Win! \nPress R to restart";
        }

        if (gameOver && !won)
        {
            scoreText.text = "You Lose! \nPress R to restart";
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            score++;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
