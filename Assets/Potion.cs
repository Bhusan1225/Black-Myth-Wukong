using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{


    [SerializeField] float potionTimer;
    [SerializeField] float countDown;

    [SerializeField] bool hasUsed;
    // Start is called before the first frame update
    void Start()
    {
        countDown = potionTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        countDown -= Time.deltaTime;
        if (countDown <= 0 && !hasUsed) 
        {

            useSpell();
        }
    }

    private void useSpell()
    {
        Debug.Log("Spell using......");
    }
}
