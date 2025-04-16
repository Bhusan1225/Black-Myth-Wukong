using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] Image foreground;
   

    public void UpdateHealthBar(float maxHealth, float currecthealth)
    {
        foreground.fillAmount = currecthealth/maxHealth;
    }
}
