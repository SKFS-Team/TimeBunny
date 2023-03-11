using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public static float timeScale = 1f;

    public float decceleration;
    public float acceleration;
    public float normalTime;

    private void Start()
    {
        timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            timeScale = decceleration;
        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            timeScale = normalTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            timeScale = acceleration;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            timeScale = normalTime;
        }
    }
}
