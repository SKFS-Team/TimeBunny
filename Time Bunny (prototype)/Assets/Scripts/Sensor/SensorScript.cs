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
    private Color startColor;
    private bool isUsed;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
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
                if (isSingleTime) { isUsed = true; }
                else Invoke("colorChange", .3f);
            }
        }
    }
    void colorChange()
    {
        rend.material.color = startColor;
    }
}