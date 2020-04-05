using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfo : MonoBehaviour
{
    int resourceAvailable = 100;
    float harvestTime = 10f;

    public bool beingGathered;
    GameObject builder;
    // Start is called before the first frame update
    void Start()
    {
        builder = GameObject.Find("Rednose");
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
            Debug.Log("Got some resources resourse left: "+resourceAvailable);
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
                builder.GetComponent<ObjectInfo>().isBusy = false;
            }
        }
    }

    public void beginGathering()
    {      
        Debug.Log("Start gathering");
        StartCoroutine("Gathering");
        beingGathered = true;
        builder.GetComponent<ObjectInfo>().isSelected = false;
        builder.GetComponent<ObjectInfo>().isBusy = true;
    }
}
