using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBar
{
    [Header("HEALTH")]

    [SerializeField] public float health = 5f;
    [SerializeField] public float maxHealth = 5f;
    public event EventHandler PlayerDeath;

    private void Start()
    {
        health = maxHealth;
        SetHealth(health);
    }

    public virtual void PlayerDamage(float damage)
    {
        health -= damage;
        ChangeActualHealth(health);
        if (health <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public override void IncreaseHealth(float amount)
    {
        float newHealth = health + amount;
        health = Mathf.Min(newHealth, maxHealth);
        ChangeActualHealth(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            PlayerDamage(1);
            Destroy(collision.gameObject);
        }
    }
}
