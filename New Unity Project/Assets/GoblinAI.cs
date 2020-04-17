using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class GoblinAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Rednose");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision occured");
        if(collision.gameObject.name == "Knight")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Rednose")
        {
            Destroy(collision.gameObject);
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
#endif
            Application.Quit();
        }
    }
}
