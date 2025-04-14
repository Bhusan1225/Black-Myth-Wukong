using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderGoblinAI : MonoBehaviour
{

    [SerializeField] float maxHealth = 200;
    [SerializeField] float currentHealth;

    [SerializeField]float speed = 4f;

    [Header("Player detect")]
    [SerializeField] GameObject player;
    [SerializeField] LayerMask playerlayer;
    [SerializeField] float visionRadious;
    [SerializeField] bool isPlayerinVisionRadious;

    private void Start()
    {
        currentHealth = maxHealth;
    }



    private void Update()
    {
       isPlayerinVisionRadious = Physics.CheckSphere(transform.position, visionRadious,playerlayer);

        if (isPlayerinVisionRadious) 
        {
            ChasePlayer();
        }
        else
        {
            //idle animation
        }
    }

    private void ChasePlayer()
    {
        transform.position += transform.forward * speed *Time.deltaTime ;
        transform.LookAt(player.transform);
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
