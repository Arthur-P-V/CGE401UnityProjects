/*
 * Arthur Peterson-Veatch
 * Prototype 1
 * Script to manage score for prototype 1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textbox;

    void Start() {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        if (score >= 3)
        {
            won = true;
            gameOver = true;
        }

        if (gameOver) {
            if (won)
            {
                textbox.text = "You Win! \nPress R to Try Again!";
            }
            else {
                textbox.text = "You Lose! \nPress R to Try Again!";
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
