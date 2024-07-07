using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : EnemyController
{
    [Header("PATROL")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime;
    private int currentWaypoint;
    private bool isWaiting;

    public override void EnemyDamage(float damageAmount)
    {
        base.EnemyDamage(damageAmount);
    }

    void Update()
    {
        if (!isWaiting)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, enemySpeed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(WaypointWait());
        }
    }

    public override void Attack()
    {
        base.Attack();
    }

    IEnumerator WaypointWait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
    }
}
