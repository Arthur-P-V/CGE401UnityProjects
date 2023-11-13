/*
		 * Arthur Peterson-Veatch
		 * Floater.cs
		 * OOP proj
		 * File to define behavior of floater enemy
		 */
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class Floater : Enemy
    {
        public NavMeshAgent agent;
        public Transform player;

        protected override void Awake()
        {
            base.Awake();
            //high health to discourage getting rid of it right at the beginning
            health = 1000;
            speed = 10f;
        }

        protected override void Attack(int amount, GameObject target)
        {
            Debug.Log("Floater Attack");
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(player.position);
            gameObject.transform.SetPositionAndRotation(new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
        }

        public override void TakeDamage(int amount)
        {
            Debug.Log("Floater Takes Damage");
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        public void Die() { 
            Destroy(gameObject);
        }
    }
}