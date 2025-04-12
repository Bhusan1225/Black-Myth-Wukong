using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatHandler : MonoBehaviour
{

    [SerializeField] float timer = 0f;

    [SerializeField] int closeCombatVal;

    [SerializeField]
    Animator animator;


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


    void CloseCombatModes()
    {
        if (Input.GetMouseButtonDown(0))
        {
            closeCombatVal = Random.Range(1, 5);

            if (closeCombatVal == 1)
            {
                //attack
                //animation
                StartCoroutine(Attack1());

            }
            if (closeCombatVal == 2) 
            {
                StartCoroutine(Attack2());
            }
            if (closeCombatVal == 3)
            {
                StartCoroutine(KickAttack3());
            }
            if (closeCombatVal == 4)
            {
                StartCoroutine(KickAttack4());
            }
            if (closeCombatVal == 5)
            {
                StartCoroutine(JumpAttack5());
            }
        }
    }

    IEnumerator Attack1()
    {
        animator.SetBool("Attack1", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attack1", false);
    }

    IEnumerator Attack2() 
    {
        animator.SetBool("Attack2", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attack2", false);
    }
    IEnumerator KickAttack3()
    {
        animator.SetBool("KickAttack3", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("KickAttack3", false);
    }

    IEnumerator KickAttack4()
    {
        animator.SetBool("KickAttack4", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("KickAttack4", false);
    }

    IEnumerator JumpAttack5()
    {
        animator.SetBool("JumpAttack5", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("JumpAttack5", false);
    }

}
