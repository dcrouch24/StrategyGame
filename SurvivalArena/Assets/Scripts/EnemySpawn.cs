using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreateEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator CreateEnemy()
    {

        while (true)
        {
            yield return new WaitForSeconds(3);
            Vector3 enemyLocation = new Vector3(0,0,0);
            int spawnPos = Random.Range(0, 4);
            if (spawnPos == 0)
                enemyLocation = new Vector3(45, 2, 45);
            else if (spawnPos == 1)
                enemyLocation = new Vector3(-45, 2, -45);
            else if (spawnPos == 2)
                enemyLocation = new Vector3(-45, 2, 45);
            else if (spawnPos == 3)
                enemyLocation = new Vector3(45, 2, -45);
            else
                Debug.Log("Enemy Spawn Failed!");

            Instantiate(enemy, enemyLocation, Quaternion.identity);
        }
    }
}
