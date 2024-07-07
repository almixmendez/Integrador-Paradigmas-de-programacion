using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour, IActivatePwrp
{
    [SerializeField] protected PowerupEffect powerupEffect;

    public void ActivarPowerup()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            powerupEffect.Apply(collision.gameObject);
            ActivarPowerup();
        }
    }
}
