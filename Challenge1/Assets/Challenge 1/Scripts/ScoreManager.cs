/*
 * Arthur Peterson-Veatch
 * Challenge 1
 * Script to Manage score for challenge 1
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int Score;
    public static bool GameOver;
    public static bool Won;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        GameOver = false;
        Won = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver) {
            scoreText.text = "Score: " + Score;

            if (Score >= 5) {
                Won = true;
                GameOver= true;
            }
        }


        

        if (GameOver) {
            if (Won)
            {
                scoreText.text = "You Won! \nPress R to restart.";
            }
            else {
                scoreText.text = "You Lose! \nPress R to restart.";
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
