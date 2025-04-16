using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ElderGoblinAI : MonoBehaviour
{
    [Header("Opponent Health")]
    [SerializeField] float maxHealth = 200;
    [SerializeField] float currentHealth;
    [SerializeField] private HealthBar healthBar;

    [SerializeField]float speed = 4f;

    [SerializeField] Animator animator;

    [Header("Player detect")]
    [SerializeField] GameObject player;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float visionRadius;
    [SerializeField] bool isPlayerinVisionRadius;
    [SerializeField] float attackRadius;

    [Header("Attack on Player")]
    public int attackVal;
    [SerializeField] float giveDamage;
    [SerializeField] float timeBtwAttack;
    [SerializeField] bool previouslyAttack;

    [Header("Attack Areas")]
    [SerializeField] float attackingRadius;
    [SerializeField] Transform attackArea;
    [SerializeField] bool isPlayerinAttackRadius;
    [SerializeField] Transform RightHand;
    [SerializeField] Transform LeftLeg;
    [SerializeField] Transform RightLeg;


    [SerializeField] Collider[] hitPlayer;
    [SerializeField] PlayerHealth playerHealth;

    [Header("PotionEffect")]
    [SerializeField]internal bool isPotionEffectActive;

    public void setPotionEffect(bool isPotionActivated)
    {
        isPotionEffectActive = isPotionActivated;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    

    private void Update()
    {
        
       isPlayerinVisionRadius = Physics.CheckSphere(transform.position, visionRadius,playerLayer);
       isPlayerinAttackRadius = Physics.CheckSphere(transform.position, attackRadius, playerLayer);

        if (isPlayerinVisionRadius && !isPlayerinAttackRadius && !isPotionEffectActive)
        {
            ChasePlayer();
        }
    
        if (!isPlayerinVisionRadius && !isPlayerinAttackRadius && !isPotionEffectActive)
        {

            animator.SetBool("Walk", false);

        }

        if (isPlayerinVisionRadius && isPlayerinAttackRadius && !isPotionEffectActive)
        {

            animator.SetBool("IdleAngry", true);
            AttackModes();
        }

       


    }

   

    private void ChasePlayer()
    {
        animator.SetBool("Walk", true);
        animator.SetBool("IdleAngry", false);
        
        transform.position += transform.forward * speed *Time.deltaTime ;
        transform.LookAt(player.transform);
    }

    private void AttackModes()
    {
        if (!previouslyAttack)
        {

            attackVal = Random.Range(1, 4);

            if (attackVal == 1)
            {
                StartCoroutine(Attack1());
                Attack();

               


            }
            if (attackVal == 2)
            {

                

                StartCoroutine(Attack2());
                Attack();
            }
            if (attackVal == 3)
            {

                
                StartCoroutine(Attack3());
                Attack();
            }
            if (attackVal == 4)
            {

               

                StartCoroutine(Attack4());
                Attack();
            }

        }
    }



    private void OnDrawGizmosSelected()
    {

        if (attackArea == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackArea.position, attackingRadius);
    }
    void Attack()
    {
        Debug.Log("Player hit by Elder Goblin");
        hitPlayer = Physics.OverlapSphere(attackArea.position, attackingRadius, playerLayer);
        foreach (Collider hit in hitPlayer)
        {
            PlayerHealth targetHealth = hit.GetComponent<PlayerHealth>();
            if (targetHealth != null)
            {
                Debug.Log("Player hit by Elder Goblin");
                targetHealth.TakeDamage(0.05f);
            }
        }

        previouslyAttack = true;
        Invoke(nameof(ActiveAttack), timeBtwAttack);
    }

    private void ActiveAttack()
    {
        previouslyAttack= false;
    }


    IEnumerator Attack1()
    {
        animator.SetBool("Attack1", true);
        speed = 0f;
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attack1", false);
        speed = 4f;
    }


    IEnumerator Attack2()
    {
        animator.SetBool("Attack2", true);
        speed = 0f;
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attack2", false);
        speed = 4f;
    }

    IEnumerator Attack3()
    {
        animator.SetBool("Attack3", true);
        speed = 0f;
        yield return new WaitForSeconds(0.2f);
        speed = 4f;
        animator.SetBool("Attack3", false);
    }

    IEnumerator Attack4()
    {
        animator.SetBool("Attack4", true);
       speed = 0f;
        yield return new WaitForSeconds(0.2f);
        speed = 4f;
        animator.SetBool("Attack4", false);
    }


    public void TakeDamage(float amout)
    {
        currentHealth -= amout;
        if(!isPotionEffectActive)
        {
            animator.SetTrigger("GetHit");
        }
     

        if (currentHealth <= 0) 
        {
            Die();
        }
        else
        {
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    private void Die()
    {
       
        animator.SetBool("isDead", true);
        animator.SetBool("Walk", false);
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
      
    }
}
