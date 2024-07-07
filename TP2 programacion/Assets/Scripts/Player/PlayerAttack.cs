using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("ATTACK")]

    [SerializeField] float damage = 1f;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;

    private Animator animator;
    private Vector3 mousePos;
    private Camera mainCam;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        direction.Normalize();
        DetermineDirection(direction);

        animator.SetTrigger("isAttacking");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyController enemyComponent = enemy.GetComponent<EnemyController>();
            if (enemyComponent != null)
            {
                enemyComponent.EnemyDamage(damage);
            }
        }
    }

    void DetermineDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                // Right
                animator.SetFloat("MoveX", 1);
                animator.SetFloat("MoveY", 0);
            }
            else
            {
                // Left
                animator.SetFloat("MoveX", -1);
                animator.SetFloat("MoveY", 0);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                // Up
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 1);
            }
            else
            {
                // Down
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", -1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}