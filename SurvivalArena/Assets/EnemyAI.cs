using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    public float attackCooldown = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerFinder.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        agent.SetDestination(target.position);
        
        FaceTarget();
        
        if(distance <= agent.stoppingDistance)
        {
            AttackPlayer();
        }

        attackCooldown -= Time.deltaTime;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        lookRotation *= Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void AttackPlayer()
    {
        if(attackCooldown <= 0)
        {
            PlayerFinder.instance.player.gameObject.GetComponent<PlayerStats>().currentHealth -= gameObject.GetComponent<EnemyStats>().attackDamage;
            attackCooldown = 1f;
        }
    }
}
