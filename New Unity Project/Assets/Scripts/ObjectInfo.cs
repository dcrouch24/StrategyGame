using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectInfo : MonoBehaviour
{
    public bool isSelected = false;
    public bool isBusy = false;
    public string objectName;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && isSelected)
        {
            RightClick();
        }
<<<<<<< Updated upstream
=======
        if(target != null && targetStats != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            agent.SetDestination(target.position);
            FaceTarget();
            if(distance <= agent.stoppingDistance)
            {
                if (target.tag == "Enemy")
                {
                    if (nextAttackTime < Time.time)
                        Attack(targetStats);
                }
                else if(target.tag == "Resource")
                {
                    isBusy = true;
                    ResourceInfo resource = target.GetComponent<ResourceInfo>();
                    resource.beginGathering();
                }
            }
        }
>>>>>>> Stashed changes
    }

    public void RightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.tag == "Ground" && !isBusy)
            {
                agent.destination = hit.point;
                Debug.Log("Moving");
            }
<<<<<<< Updated upstream
=======
            if(hit.collider.tag == "Enemy" && !isBusy)
            {
                target = hit.collider.transform;
                targetStats = hit.collider.GetComponent<EnemyStats>();

            }
            if(hit.collider.tag == "Resource" && !isBusy)
            {
                target = hit.collider.transform;
            }
        }
    }

    public void Attack(EnemyStats enemy)
    {
        anim.SetTrigger("Attack");
        
        StartCoroutine(DoDamage(attackDelay));

        if (OnAttack != null)
            OnAttack();

        nextAttackTime = Time.time + attackSpeed;
    }

    IEnumerator DoDamage(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetStats.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
>>>>>>> Stashed changes
        }
    }
}
