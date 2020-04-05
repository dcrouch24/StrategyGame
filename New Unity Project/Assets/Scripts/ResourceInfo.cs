using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfo : MonoBehaviour
{
    int resourceAvailable = 100;
    float harvestTime = 10f;

    public bool beingGathered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Gathering()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Got some resources");
            ResourceGather();
        }

    }

    public void ResourceGather()
    {
        if(beingGathered)
        {
            resourceAvailable -= 10;
            if(resourceAvailable <= 0)
            {
                Debug.Log("Destroyed Node");
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Rednose")
        {
            Debug.Log("Collision Detected");
            StartCoroutine("Gathering");
        }
    }
}
