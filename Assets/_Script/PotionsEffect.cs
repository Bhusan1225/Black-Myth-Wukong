using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsEffect : MonoBehaviour
{

    [SerializeField] ElderGoblinAI ElderGoblinAI;
    [SerializeField] float immobilizeEffectTime;

    Animator animator;

    private float countdownTimer = 0f;
    private bool isCountingDown = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isCountingDown)
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0f)
            {
                OverImmobilize();
            }
        }
    }

    public void Immobilize()
    {
        Debug.Log("Immobilize is activated....");
        animator.SetBool("sitting", true);
        //ElderGoblinAI.isPotionEffectActive = true;
        ElderGoblinAI.setPotionEffect(true);
        //GetComponent<Collider>().enabled = false;
        countdownTimer = immobilizeEffectTime;
        isCountingDown = true;
    }

    private void OverImmobilize()
    {
        Debug.Log("Immobilize is deactivated....");
        animator.SetBool("sitting", false);
        //ElderGoblinAI.isPotionEffectActive = false;
        ElderGoblinAI.setPotionEffect(false);
        //GetComponent<Collider>().enabled = true;
        isCountingDown = false;
        countdownTimer = 0f;
    }
}

