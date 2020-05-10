using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInfo : MonoBehaviour
{
    int resourceAvailable = 100;
    float harvestTime = 10f;
    public bool beingGathered;
    GameObject builder;
    [SerializeField] public Slider progress;
    [SerializeField] private Canvas progressMap;
    public Slider slideObj;
    public GameObject spawner;
    public GameObject enemy;

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
            slideObj.value += .1f;
            ResourceGather();
            StartCoroutine("SpawnEnemies");
        }

    }

    IEnumerator SpawnEnemies()
    {
        //Instantiate(enemy, spawner.transform);
        yield return new WaitForSeconds(2);
    }

    public void ResourceGather()
    {
        if(beingGathered)
        {
            resourceAvailable -= 10;
            if(resourceAvailable <= 0)
            {
                Destroy(slideObj);
                Debug.Log("Destroyed Node");
                Destroy(gameObject);
                builder.GetComponent<ObjectInfo>().isBusy = false;
            }
        }
    }

    public void beginGathering()
    {
        slideObj = Instantiate(progress, transform.position+new Vector3(0,5,0), progress.transform.rotation, progressMap.transform);
        slideObj.value = 0;
        Debug.Log("Start gathering");
        StartCoroutine("Gathering");
        beingGathered = true;
        builder.GetComponent<ObjectInfo>().isSelected = false;
        builder.GetComponent<ObjectInfo>().isBusy = true;
    }
}
