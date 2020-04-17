using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerFinder.instance.player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = playerStats.currentAmmo.ToString();
    }
}
