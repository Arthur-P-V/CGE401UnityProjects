/*
 Arthur Peterson-Veatch
 Challenge 4
 EnemyX
 A script to handle the Enemy behavior
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    public SpawnManagerX spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            spawnManager.enemyGoalHits++;
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            spawnManager.playerGoalHits++;
            Destroy(gameObject);
        }

    }

}
