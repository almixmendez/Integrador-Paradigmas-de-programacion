using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : EnemyController
{
    [Header("SHOOTING")]
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoots;
    [SerializeField] private float projectileSpeed;

    public override void EnemyDamage(float damageAmount)
    {
        base.EnemyDamage(damageAmount);
    }

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShoots);
            GameObject playerObject = GameObject.FindWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Vector2 directionToPlayer = (player.position - transform.position).normalized;
                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                projectileRb.velocity = directionToPlayer * projectileSpeed;
                Destroy(projectile, 5f);
            }
            else
            {
                Debug.Log("No se encontró un GameObject con la etiqueta 'Player'. El proyectil no se lanzará.");
            }
        }
    }
}
