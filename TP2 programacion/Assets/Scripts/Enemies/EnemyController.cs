using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [Header("ENEMY BASE")]
    // Vida.
    [SerializeField] protected float enemyhealth = 3f;
    [SerializeField] protected float maxHealth = 3f;
    protected private PlayerHealth playerHealth;

    // Ataques.
    [SerializeField] protected Transform player;
    [SerializeField] protected float damageAmount = 1f;
    [SerializeField] protected float attackCooldown = 1f;
    [SerializeField] protected float enemySpeed;

    protected bool canAttack = true;

    private void Start()
    {
        enemyhealth = maxHealth;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public virtual void EnemyDamage(float damageAmount)
    {
        enemyhealth -= damageAmount;

        if (enemyhealth <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.PlayerDamage(damageAmount);
        }
    }

    public virtual IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
