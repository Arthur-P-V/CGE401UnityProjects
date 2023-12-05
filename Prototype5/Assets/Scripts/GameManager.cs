/*
	* Arthur Peterson-Veatch
	* GameManager.cs
	* Assignment 8
	* GameManager and UI control
*/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;

    public GameObject titleScreen;

    public bool isGameActive;

    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(int difficulty) {

        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive= false;
    }

     IEnumerator SpawnTarget()
    {
        while (isGameActive) { 
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //UpdateScore(5);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
