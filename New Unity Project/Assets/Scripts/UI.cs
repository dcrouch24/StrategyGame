using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private Text TimeDisplay;
    public float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountUp");
    }

    // Manages everything dealing with the timer. Text, value, when the game is paused, and when changing levels
    IEnumerator CountUp()
    {
        while (time >= 0)
        {
            TimeDisplay.text = "Time:" + (int)time; // Updates the timeText
            yield return new WaitForSeconds(1);     // Waits a full second before updating time value 
            time += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
