using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrowManager : MonoBehaviour
{
    public float throwForce = 10f;
    public Transform potionArea;
    public GameObject potionPrefab;

    public PotionCollector potionCollector;
    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && potionCollector.potionCounting > 0)
        {
            StartCoroutine(ThrowAnimation());
        }
    }

    void ThrowPotion()
    {
        GameObject potion = Instantiate(potionPrefab, potionArea.transform.position, potionArea.transform.rotation);
        Rigidbody rb = potion.GetComponent<Rigidbody>();
        rb.AddForce(potionArea.transform.forward * throwForce, ForceMode.VelocityChange);

        // Reduce the count after throwing
        potionCollector.potionCounting--;
        potionCollector.PotionCountText.text = "Potion: " + potionCollector.potionCounting.ToString();
    }

    IEnumerator ThrowAnimation()
    {
        animator.SetBool("PotionThrow", true);
        yield return new WaitForSeconds(0.4f);
        ThrowPotion();
        yield return new WaitForSeconds(1f);
        animator.SetBool("PotionThrow", false);
    }
}

