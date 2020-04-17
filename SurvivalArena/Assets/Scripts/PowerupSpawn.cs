using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    public GameObject[] powerups;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreatePowerup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreatePowerup()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(10);
            Vector3 powerupLocation = new Vector3(Random.Range(-45, 45), 2, Random.Range(-45, 45));
            
            Instantiate(powerups[Random.Range(0, 3)], powerupLocation, Quaternion.identity);
        }
    }
}
