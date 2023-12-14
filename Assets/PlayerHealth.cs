using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthbar;
    public float HealthLeft = 100f;


    public void TakenDamage(float health)
    {
        HealthLeft -= health;
        healthbar.fillAmount = HealthLeft / 100;
    }

    public void RegenHelth(float health)
    {
        HealthLeft += health;
        healthbar.fillAmount = HealthLeft / 100;
    }
}
