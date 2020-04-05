using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectInfo : MonoBehaviour
{
    public bool isSelected = false;

    public string objectName;

    private NavMeshAgent agent;

    int maxHealth = 100;
    int health;

    int attackPower = 10;
    float attackSpeed = 1f;
    float attackRange = 1f;

    float distToTarget;
    GameObject attackTarget;

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


        if (attackTarget != null)
        {
            distToTarget = Vector3.Distance(gameObject.transform.position, attackTarget.transform.position);
            if(distToTarget < attackRange)
            {
                agent.destination = gameObject.transform.position;
            }
        }
    }

    public void RightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.tag == "Ground")
            {
                agent.destination = hit.point;
                Debug.Log("Moving");
            }
            else if(hit.collider.tag == "Enemy")
            {
                attackTarget = hit.collider.gameObject;
                agent.destination = attackTarget.transform.position;
            }
        }
    }
}
