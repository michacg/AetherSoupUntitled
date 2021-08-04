using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mobile enemies encompass all enemies that can move towards the player.
public class MobileEnemy : EnemyBase
{
    [SerializeField] private float lookRadius = 10f;
    void Update()
    {
        Idle();
    }

    void FacePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public override void Attack()
    {
        
    }

    public override void Idle()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceFromPlayer <= lookRadius)
        {
            Aggro(distanceFromPlayer);
        }
    }

    public virtual void Aggro(float distance)
    {
        agent.SetDestination(player.position);

        if (distance <= agent.stoppingDistance)
        {
            FacePlayer();
        }
    }
}
