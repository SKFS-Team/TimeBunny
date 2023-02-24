using UnityEngine;

public class TimeChange : MonoBehaviour
{
    public float decceleration;
    public float acceleration;
    public float normalTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = decceleration;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = acceleration;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = normalTime;
        }
    }
}
