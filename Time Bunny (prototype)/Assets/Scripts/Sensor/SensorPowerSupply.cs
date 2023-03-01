using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPowerSupply : MonoBehaviour
{
    [SerializeField] private bool needEnergy = true;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "Lazer")
        {
            needEnergy = false;
            Debug.Log("NeedEnergy == false");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.tag == "Lazer")
        {
            needEnergy = true;
            Debug.Log("NeedEnergy == true");
        }
    }
}
