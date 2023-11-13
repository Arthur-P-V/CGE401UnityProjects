/*
		 * Arthur Peterson-Veatch
		 * Golem.cs
		 * OOP proj
		 * Golem class, inherits from Enemy
		 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    protected int damage;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 120;
        GameManager.Instance.score += 2;
    }

    protected override void Attack(int amount, GameObject target) {
        Debug.Log("Golem Attacks!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took " + amount + " damage!");
    }
}
