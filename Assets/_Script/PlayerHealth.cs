using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 200;
    [SerializeField] float currentHealth;
    //[SerializeField] Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
       

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Destroy(gameObject);
        

    }
}
