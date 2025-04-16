using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PotionCollector : MonoBehaviour
{
    [SerializeField] int potionCount;
    [SerializeField] TextMeshProUGUI PotionCountText;
  

    // Start is called before the first frame update
    void Start()
    {
        potionCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Collection()
    {
        potionCount++;
        PotionCountText.text = "Potion: " + potionCount.ToString();
    }
}
