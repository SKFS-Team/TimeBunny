using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectToAffect;
    [SerializeField] private string Tag;
    [SerializeField] private string TagSeek;
    [SerializeField] private string TagChange;
    [SerializeField] private Color ActivatedColor;
    [SerializeField] private Color InvertedColor;
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
            if(other.gameObject.tag == TagSeek && !isUsed)
            {
                rend.material.color = ActivatedColor;
                gameObjectToAffect.GetComponent<ObjectsAffectedBySensorsScript>().isActivated = true;
                if (isSingleTime) { isUsed = true; }
                else Invoke("colorChange", .3f);
            }
        }
        else if(Tag == "Inventor")
        {
            if(other.gameObject.tag == TagSeek && !isUsed)
            {
                rend.material.color = InvertedColor;
                gameObjectToAffect.GetComponent<ObjectsAffectedBySensorsScript>().Tag = TagChange;
                if (isSingleTime) { isUsed = true; }
                else Invoke("colorChange", .5f);
            }
        }
    }
    void colorChange()
    {
        rend.material.color = startColor;
    }
}