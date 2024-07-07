using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        float initialHealth = 5;
        SetHealth(initialHealth);
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeActualHealth(float healthAmount)
    {
        slider.value = healthAmount;
    }

    public virtual void IncreaseHealth(float amount)
    {
        float newHealth = slider.value + amount;
        ChangeActualHealth(newHealth);
    }

    public void SetHealth(float healthAmount)
    {
        ChangeMaxHealth(healthAmount);
        ChangeActualHealth(healthAmount);
    }
}
