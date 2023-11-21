/* 
 Arthur Peterson-Veatch
 Prototype 4
 EnemyAI.cs
 Script to handle ememy Movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        //add force toward the direction from the player to the enemy


        //Vector for direction from enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
