using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsAffectedBySensorsScript : MonoBehaviour
{
    [SerializeField] private string Tag;
    [SerializeField] public bool isActivated;
    // posChange tag function
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private Vector3 movePerTick;
    [SerializeField] private float Seconds;
    public int counter;
    private bool isLowered;
    public bool isActive;
    // placeholder function

    void Update()
    {
        if(isActivated)
        {
            if(Tag == "posChange" && !isLowered && !isActive)
            {
                isActive = true;
                TickSet();
                isActivated = false;
            }
            else if(Tag == "posChange" && isLowered && !isActive)
            { 
                isActive = true;
                PosChange();
            }
        }
    }
    void TickSet()
    {
        movePerTick = (endPos - startPos) / 20;
        Invoke("PosChange", Seconds / 20);
    }
    void PosChange()
    {
        if (counter < 20 && !isLowered) 
        {
            counter++;
            Invoke("PosChange", Seconds / 20);
            gameObject.transform.position = transform.position + movePerTick;
        }
        else if(counter < 20 && isLowered)
        {
            counter++;
            Invoke("PosChange", Seconds / 20);
            gameObject.transform.position = transform.position - movePerTick;
        }
        else if(counter == 20)
        { 
            if(!isLowered) { isLowered = true; }
            else if(isLowered) { isLowered = false; }
            isActive = false;
            isActivated = false;
            counter = 0;
        }
    }
}