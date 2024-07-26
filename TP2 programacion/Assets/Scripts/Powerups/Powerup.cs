using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que contiene cada objeto powerup.

public class Powerup : MonoBehaviour, IDestroyPwrp
{
    [SerializeField] protected PowerupEffect powerupEffect;

    public void DestroyPwrp()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            powerupEffect.Apply(collision.gameObject);
            DestroyPwrp();
        }
    }
}
