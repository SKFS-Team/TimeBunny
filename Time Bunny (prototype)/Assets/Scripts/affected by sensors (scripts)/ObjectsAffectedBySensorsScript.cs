using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsAffectedBySensorsScript : MonoBehaviour
{
    [SerializeField] public string Tag;
    [SerializeField] public bool isActivated;
    private bool isActive;
    // posChange tag function
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private Vector3 movePerTick;
    [SerializeField] private float secondsForMove;
    [SerializeField] private int amountOfTicksForMove;
    private int counterForMove;
    private bool isMoved;
    // scaleChange tag function
    [SerializeField] private Vector3 startScale;
    [SerializeField] private Vector3 endScale;
    [SerializeField] private Vector3 scaleChangePerTick;
    [SerializeField] private float secondsForScale;
    [SerializeField] private int amountOfTicksForScale;
    private int counterForScale;
    private bool isScaled;
    void Update()
    {
        if(isActivated)
        {
            if(Tag == "posChange" && !isMoved && !isActive)
            {
                isActive = true;
                TickSet(startPos, endPos, Tag);
                isActivated = false;
            }
            else if(Tag == "posChange" && isMoved && !isActive)
            { 
                isActive = true;
                PosChange();
            }
            if(Tag == "scaleChange" && !isScaled && !isActive)
            {
                isActive = true;
                TickSet(startScale, endScale, Tag);
            }
            else if(Tag == "scaleChange" && !isScaled && !isActive)
            {
                isActive = true;
                ScaleChange();
            }
        }
    }
    void TickSet(Vector3 startVector, Vector3 endVector, string function)
    {
        if (function == "posChange")
        {
            movePerTick = (endVector - startVector) / amountOfTicksForMove;
            Invoke("PosChange", secondsForMove / amountOfTicksForMove);
        }
        else if(function == "scaleChange")
        {
            scaleChangePerTick = (endVector - startVector) / amountOfTicksForScale;
            Invoke("ScaleChange", secondsForScale / amountOfTicksForScale);
        }
    }
    // posChange functions
    void PosChange()
    {
        if (counterForMove < amountOfTicksForMove && !isMoved) 
        {
            counterForMove++;
            Invoke("PosChange", secondsForMove / amountOfTicksForMove);
            gameObject.transform.position = transform.position + movePerTick;
        }
        else if(counterForMove < amountOfTicksForMove && isMoved)
        {
            counterForMove++;
            Invoke("PosChange", secondsForMove / amountOfTicksForMove);
            gameObject.transform.position = transform.position - movePerTick;
        }
        else if(counterForMove == amountOfTicksForMove)
        { 
            if(!isMoved) { isMoved = true; }
            else if(isMoved) { isMoved = false; }
            isActive = false;
            isActivated = false;
            counterForMove = 0;
        }
    }
    // scaleChange functions
    void ScaleChange()
    {
        if (counterForScale < amountOfTicksForScale && !isScaled)
        {
            counterForScale++;
            Invoke("ScaleChange", secondsForScale / amountOfTicksForScale);
            gameObject.transform.localScale = transform.localScale + scaleChangePerTick;
        }
        else if (counterForScale < amountOfTicksForScale && isScaled)
        {
            counterForScale++;
            Invoke("ScaleChange", secondsForScale / amountOfTicksForScale);
            gameObject.transform.localScale = transform.localScale - scaleChangePerTick;
        }
        else if (counterForScale == amountOfTicksForScale)
        {
            if (!isScaled) { isScaled = true; }
            else if (isScaled) { isScaled = false; }
            isActive = false;
            isActivated = false;
            counterForScale = 0;
        }
    }
}