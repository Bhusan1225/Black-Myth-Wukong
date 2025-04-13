using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderGoblinAI : MonoBehaviour
{
    public float maxHealth = 200;
    public float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amout)
    {
        currentHealth -= amout;
        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
       Destroy(gameObject);
    }
}
