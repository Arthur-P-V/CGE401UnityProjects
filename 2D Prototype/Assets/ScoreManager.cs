/*
 Arthur Peterson-Veatch
 Prototype 4
 This is a script to manage score and win conditions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public bool outOfBounds;
    public bool won;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (won) {
            scoreText.text = "You Won!\nPress R to restart!";
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (outOfBounds)
        {
            scoreText.text = "You Lost!\nPress R to restart!";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }

/*    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish")) {
            won = true;
        }
        else if (collision.CompareTag("OB"))
        {
            outOfBounds = true;
        }
    }*/
}
