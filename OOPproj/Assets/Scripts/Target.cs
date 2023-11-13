/*
 Arthur Peterson-Veatch
 3d prototype
 This is a script to define the behavior of a target
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Enemy
{

    public override void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Die();
        }
    }

    protected override void Attack(int amount, GameObject target)
    {
        throw new NotImplementedException();
    }

    protected override void Awake()
    {
        base.Awake();
        health = 50;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
