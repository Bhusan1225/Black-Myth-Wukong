using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PotionCollector : MonoBehaviour
{
    [SerializeField] internal int potionCounting;
    [SerializeField] internal TextMeshProUGUI PotionCountText;
  

    // Start is called before the first frame update
    void Start()
    {
        potionCounting = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Collection()
    {
        potionCounting++;
        PotionCountText.text = "Potion: " + potionCounting.ToString();
    }
}
