using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    [SerializeField] private GameObject gameobjectToAffect;
    [SerializeField] private string Tag;
    [SerializeField] private Color ActivatedColor;
    [SerializeField] private bool isSingleTime;
    private Renderer rend;
    private bool isUsed;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Tag == "Object")
        {
            if(other.gameObject.tag == "Telekinesible" && !isUsed)
            {
                rend.material.color = ActivatedColor;
                gameobjectToAffect.GetComponent<ObjectsAffectedBySensorsScript>().isActivated = true;
                if(isSingleTime) { isUsed = true; }
            }
        }
    }
}