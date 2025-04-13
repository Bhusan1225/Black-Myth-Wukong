using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatHandler : MonoBehaviour
{

    [SerializeField] float timer = 0f;

    [SerializeField] int closeCombatVal;

    [SerializeField]
    Animator animator;


    [SerializeField] Transform attackArea;
    [SerializeField] float attackRadius;
    [SerializeField] float giveDamage = 10f;
    [SerializeField] LayerMask OpponentLayer;

    [SerializeField] Collider[] hitOpponent;
    [SerializeField] ElderGoblinAI ai;

    //[SerializeField] Transform LeftHand;
    [SerializeField] Transform RightHand;
    [SerializeField] Transform LeftLeg;
    [SerializeField] Transform RightLeg;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            timer += Time.deltaTime;

        }
        else
        {
            //Debug.Log("CloseCombat mode is ON");
            animator.SetBool("CloseCombatActive", true);
            timer = 0f;
        }

        if (timer > 10f)
        {
            //Debug.Log("CloseCombat mode is OFF");
            animator.SetBool("CloseCombatActive", true);
        }
        CloseCombatModes();
    }


    void Attack()
    {
        hitOpponent = Physics.OverlapSphere(attackArea.position, attackRadius, OpponentLayer);
        foreach (Collider opponent in hitOpponent)
        {
            ElderGoblinAI elderGoblinAI = opponent.GetComponent<ElderGoblinAI>();

            if (elderGoblinAI != null)
            {
                elderGoblinAI.TakeDamage(giveDamage);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {

        if (attackArea == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackArea.position, attackRadius);   
    }
    void CloseCombatModes()
    {
        if (Input.GetMouseButtonDown(0))
        {
            closeCombatVal = Random.Range(1, 6);

            if (closeCombatVal == 1)
            {
                //attack
                attackArea = RightHand;
                attackRadius = 0.5f;
                Attack();
                //animation
                StartCoroutine(Attack1());


            }
            if (closeCombatVal == 2) 
            {
                attackArea = RightHand;
                attackRadius = 0.5f;
                Attack();
                StartCoroutine(Attack2());
            }
            if (closeCombatVal == 3)
            {

                attackArea = RightLeg;
                attackRadius = 0.5f;
                Attack();
                StartCoroutine(KickAttack3());
            }
            if (closeCombatVal == 4)
            {
                attackArea = RightLeg;
                attackRadius = 0.5f;
                Attack();
                StartCoroutine(KickAttack4());
            }
            if (closeCombatVal == 5)
            {
                Debug.Log("Attack jump attack 5");
                attackArea = RightHand;
                attackRadius = 0.5f;
                Attack();
                StartCoroutine(JumpAttack5());
            }
        }
    }

    IEnumerator Attack1()
    {
        animator.SetBool("Attack1", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Attack1", false);
    }

    IEnumerator Attack2() 
    {
        animator.SetBool("Attack2", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Attack2", false);
    }
    IEnumerator KickAttack3()
    {
        animator.SetBool("KickAttack3", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("KickAttack3", false);
    }

    IEnumerator KickAttack4()
    {
        animator.SetBool("KickAttack4", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("KickAttack4", false);
    }

    IEnumerator JumpAttack5()
    {
        animator.SetBool("JumpAttack5", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("JumpAttack5", false);
    }

}
