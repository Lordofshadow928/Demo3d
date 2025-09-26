using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Image healthValue;

    private void Start()
    {
        health.onHealthChanged.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar(int HealthPoint, int maxHealthPoint)
    {
        healthValue.fillAmount = 1f * HealthPoint / maxHealthPoint;
    }
}
