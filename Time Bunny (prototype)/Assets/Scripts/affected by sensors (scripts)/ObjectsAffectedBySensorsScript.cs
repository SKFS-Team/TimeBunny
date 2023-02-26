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
    [SerializeField] private int amountOfTicks;
    private int counter;
    private bool isLowered;
    private bool isActive;
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
        movePerTick = (endPos - startPos) / amountOfTicks;
        Invoke("PosChange", Seconds / amountOfTicks);
    }
    void PosChange()
    {
        if (counter < amountOfTicks && !isLowered) 
        {
            counter++;
            Invoke("PosChange", Seconds / amountOfTicks);
            gameObject.transform.position = transform.position + movePerTick;
        }
        else if(counter < amountOfTicks && isLowered)
        {
            counter++;
            Invoke("PosChange", Seconds / amountOfTicks);
            gameObject.transform.position = transform.position - movePerTick;
        }
        else if(counter == amountOfTicks)
        { 
            if(!isLowered) { isLowered = true; }
            else if(isLowered) { isLowered = false; }
            isActive = false;
            isActivated = false;
            counter = 0;
        }
    }
}