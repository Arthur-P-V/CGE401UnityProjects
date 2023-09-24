/*
Arthur Peterson-Veatch
Prototype 3 part 1
Code to manage UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;
    public PlayerController playerControllerScript;

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null) {
            scoreText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver) {
            scoreText.text = "Score: " + score;
        }

        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose! \nPress R to try again!";
        }

        if (score >=10) {
            playerControllerScript.gameOver = true;
            won = true;

            //stop player from running

            scoreText.text = "You Win! \nPress R to try again!";
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
