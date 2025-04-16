using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{


    [SerializeField] float potionTimer;
    [SerializeField] float potionEffectTimer;
    [SerializeField] float countDown;

    [SerializeField] float radius;

    [SerializeField] bool hasUsed;

    [SerializeField] int potionCount = 4;

    [SerializeField] Collider[] hit;
    [SerializeField] PotionsEffect PotionEffectEnemy;
    GameObject particleEffect;
    public GameObject potionParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        countDown = potionTimer;
    }

    // Update is called once per frame
    void Update()
    {
        PotionActivation();

    }

    void PotionActivation()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && !hasUsed)
        {

            TriggerPotionEffect();
            potionCount--;
            hasUsed = true;

            Invoke(nameof(DestroyPotionEffect), potionEffectTimer);
        }
    }

    private void DestroyPotionEffect()
    {
        
        Destroy(gameObject);
    }

    private void TriggerPotionEffect()
    {
        
        //particleEffect =Instantiate(potionParticleEffect, transform.position, transform.rotation);
        particleEffect = Instantiate(potionParticleEffect, (transform.position ), Quaternion.identity);
        hit = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider enemy in hit)
        {
            PotionEffectEnemy = enemy.GetComponent<PotionsEffect>();
            if (PotionEffectEnemy != null)
            {
                
                PotionEffectEnemy.Immobilize();
                
            }
            
        }

        Invoke(nameof(DestroyPotionParticleEffect), potionEffectTimer);
    }

    private void DestroyPotionParticleEffect()
    {
        Destroy(particleEffect);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

   
}
