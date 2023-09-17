/*
* Arthur Peterson-Veatch
* Challenge 2
* This script manages the scoring and health system
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public GameObject gameOverText;
    public GameObject winText;
    public int score;
    public int health = 5;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        healthText.text = "Health: 5";

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

        if (score >=5 ) {
            gameOver = true;
            winText.SetActive(true);
        }

        if (health <= 0) {
            gameOver = true;
            gameOverText.SetActive(true);
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
