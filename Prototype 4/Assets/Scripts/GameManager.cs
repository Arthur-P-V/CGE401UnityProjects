/* 
 Arthur Peterson-Veatch
 Prototype 4
 GameManager.cs
 Script to handle win conditions and UI
 */




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public SpawnManager spawnManager;
    public GameObject player;
    public Text waveText;
    public Text tutorialText;
    public bool gameOver;
    public bool win;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave " + spawnManager.waveNumber;
        tutorialText.text = "Get past wave 10 to win!\nIf you fall off you lose!\nSpace to continue";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorialText.enabled = false;
            player.GetComponent<PlayerController>().enabled = true;
            spawnManager.gameObject.SetActive(true);
            waveText.enabled = true;
        }

        if (player.transform.position.y < -10) {
            gameOver = true;
        }

        if (gameOver)
        {
            if (win)
            {
                waveText.text = "You Win!\nPress R to restart!";
            }
            else {
                waveText.text = "You Lose!\nPress R to restart!";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (spawnManager.waveNumber > 10 && !gameOver) {
            win = true;
            gameOver = true;
        }

    }
}
