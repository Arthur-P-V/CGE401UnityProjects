/*
 Arthur Peterson-Veatch
 Challenge 4
 GameManager
 A script to handle UI and win conditions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public SpawnManagerX spawnManager;
    public PlayerControllerX player;
    public Text waveText;
    public Text tutorialText;
    public bool gameOver;
    public bool won;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorialText.enabled = false;
            spawnManager.gameObject.SetActive(true);
            waveText.enabled = true;
            player.enabled = true;
        }
        if (!gameOver)
        {
            waveText.text = "Wave " + (spawnManager.waveCount - 1);
        }
        

        if ((spawnManager.waveCount - 1) > 10) {
            won = true;
            gameOver = true;
            
        }

        if (gameOver) {
            spawnManager.enabled = false;
            if (won)
            {
                waveText.text = "You Won!\n press R to restart!";
            }
            else {
                waveText.text = "You Lose!\n Press R to restart!";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
