using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPowerSupply : MonoBehaviour
{
    [SerializeField] private ObjectRotator thisGameObjectButton;
    [SerializeField] private float GiveEnergy;
    private float maxCapacity = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer" && maxCapacity > thisGameObjectButton.needEnergy)
        {
            var otherLazer = other.gameObject.GetComponentInChildren<ObjectRotator>();
            otherLazer.needEnergy -= GiveEnergy;
            thisGameObjectButton.needEnergy += GiveEnergy;
        }
    }
}
