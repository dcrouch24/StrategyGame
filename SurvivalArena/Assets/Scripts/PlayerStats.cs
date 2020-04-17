using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public int currentAmmo = 0;
    public int maxAmmo = 20;

    public int fireballs = 0;
    public int maxFireballs = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected: " + collision.gameObject.name);
        if(collision.gameObject.tag == "Powerup")
        {
            if(collision.gameObject.name == "Health(Clone)")
            {
                if (currentHealth < maxHealth - 10)
                    currentHealth += 10;
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.name == "MannaPot(Clone)")
            {
                Debug.Log("Got Manna!");
                if (fireballs < maxFireballs)
                    fireballs += 1;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Ammo(Clone)")
            {
                Debug.Log("Got ammo!");
                if (currentAmmo < maxAmmo - 5)
                    currentAmmo += 5;
                Destroy(collision.gameObject);
            }
        }
    }
}
