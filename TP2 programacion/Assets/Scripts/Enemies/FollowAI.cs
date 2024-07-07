using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : EnemyController
{
    [Header("FOLLOW")]
    [SerializeField] private float minDistance;

    public override void EnemyDamage(float damageAmount)
    {
        base.EnemyDamage(damageAmount);
    }

    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
            }
            else
            {
                if (canAttack)
                {
                    Attack();
                    StartCoroutine(AttackCooldown());
                }
            }
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}
