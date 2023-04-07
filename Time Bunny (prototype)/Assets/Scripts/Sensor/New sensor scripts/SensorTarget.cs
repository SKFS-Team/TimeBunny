using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorTarget : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private string funcion;
    public bool funcActivate;
    [SerializeField] private bool isActivated;
    public bool isObjectInLazer;
    public bool objectsInParent;

    [Header("SensorLazerScriptData")]
    [SerializeField] public SensorLazerScript sensLazScript;
    [SerializeField] public Vector3 sensLazVectorBegin;
    [SerializeField] public Vector3 sensLazVectorEnd;
    private Vector3 sensLazVectorMove;
    private int sensLazCount;
    [SerializeField] public int sensLazTicks;
    [SerializeField] public float sensLazSec;

    [Header("PositionChange")]
    [SerializeField] private Vector3 posStart;
    [SerializeField] private Vector3 posEnd;
    private Vector3 posMove;
    [SerializeField] private int posTicks;
    private int posCounter;
    [SerializeField] private float posSec;
    [SerializeField] private bool isMoved;

    [Header("ScaleChange")]
    [SerializeField] private Vector3 scaleStart;
    [SerializeField] private Vector3 scaleEnd;
    private Vector3 scaleMove;
    [SerializeField] private int scaleTicks;
    private int scaleCounter;
    [SerializeField] private float scaleSec;
    [SerializeField] private bool isScaled;

    [Header("RotationChange")]
    [SerializeField] private Vector3 rotStart;
    [SerializeField] private Vector3 rotEnd;
    private Vector3 rotMove;
    private Vector3 curRot;
    [SerializeField] private int rotTicks;
    private int rotCounter;
    [SerializeField] private float rotSec;
    [SerializeField] private bool isRotated;

    [Header("Teleport (To Be Done)")]
    [SerializeField] private Vector3 teleportStart;
    [SerializeField] private Vector3 teleportEnd;
    [SerializeField] private float teleportDelayTime;
    [SerializeField] private bool reversedTeleport; // коли true то телепортує до teleportStart. коли false то телепортує до teleportEnd
    [SerializeField] private bool isOneWay;

    private void Start()
    {
        TickSet();
        curRot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }
    void Update()
    {
        if(funcActivate)
        {
            if(sensLazScript != null && !isActivated)
            {
                ExtraTickSet();
            }
            if(!isActivated)
            {
                switch(funcion)
                {
                    case "PositionChange":
                        if (!isMoved)
                            StartCoroutine(PositionChangeBegin());
                        else if (isMoved)
                            StartCoroutine(PositionChangeEnd());                       
                        isActivated = true;
                        break;
                    case "ScaleChange":
                        if(!isScaled) 
                            StartCoroutine(ScaleChangeBegin());
                        else if(isScaled) 
                            StartCoroutine(ScaleChangeEnd());
                        isActivated = true;
                        break;
                    case "RotationChange":
                        if (!isRotated) 
                            StartCoroutine(RotationChangeBegin());
                        else if (isRotated) 
                            StartCoroutine(RotationChangeEnd());
                        isActivated = true;
                        break;
                }
            }
            funcActivate = false;
        }
    }
    private void TickSet()
    {
        if(posSec != 0)
            posMove = (posEnd - posStart) / posTicks;
        if(scaleTicks != 0)
            scaleMove = (scaleEnd - scaleStart) / scaleTicks;
        if(rotTicks != 0)
            rotMove = (rotEnd - rotStart) / rotTicks;

    }
    private void ExtraTickSet()
    {
        sensLazVectorMove = (sensLazVectorEnd - sensLazVectorBegin) / sensLazTicks;
    }

    IEnumerator PositionChangeBegin()
    {
        transform.position = transform.position + posMove;
        posCounter++;
        yield return new WaitForSeconds(posSec / posTicks);
        if (posCounter < posTicks && isObjectInLazer)
        {
            StartCoroutine(PositionChangeBegin());
        }
        else if(!isObjectInLazer)
        {
            StartCoroutine(PositionChangeEnd());
        }
        else
        {
            isMoved = true;
            isActivated = false;
        }
    }
    IEnumerator PositionChangeEnd()
    {
        transform.position = transform.position - posMove;
        posCounter--;
        yield return new WaitForSeconds(posSec / posTicks);
        if (posCounter > 0)
        {
            StartCoroutine(PositionChangeEnd());
        }
        else
        {
            isMoved = false;
            isActivated = false;
        }
    }


    IEnumerator ScaleChangeBegin()
    {
        transform.localScale = transform.localScale + scaleMove;
        scaleCounter++;
        yield return new WaitForSeconds(scaleSec / scaleTicks);
        if(scaleCounter < scaleTicks)
            StartCoroutine (ScaleChangeBegin());
        else
        {
            isScaled = true;
            scaleCounter = 0;
            isActivated = false;
        }
    }
    IEnumerator ScaleChangeEnd()
    {
        transform.localScale = transform.localScale - scaleMove;
        scaleCounter++;
        yield return new WaitForSeconds(scaleSec / scaleTicks);
        if (scaleCounter < scaleTicks)
            StartCoroutine(ScaleChangeEnd());
        else
        {
            isScaled = false;
            scaleCounter = 0;
            isActivated = false;
        }
    }
    IEnumerator RotationChangeBegin()
    {
        transform.rotation = Quaternion.Euler(curRot+= rotMove);
        rotCounter++;
        yield return new WaitForSeconds(rotSec / rotTicks);
        if(rotCounter < rotTicks)
            StartCoroutine(RotationChangeBegin());
        else
        {
            isRotated = true;
            rotCounter = 0;
            isActivated = false;
        }
    }
    IEnumerator RotationChangeEnd()
    {
        transform.rotation = Quaternion.Euler(curRot -= rotMove);
        rotCounter++;
        yield return new WaitForSeconds(rotSec / rotTicks);
        if (rotCounter < rotTicks)
            StartCoroutine(RotationChangeEnd());
        else
        {
            isRotated = false;
            rotCounter = 0;
            isActivated = false;
        }
    }

    IEnumerator Teleportation()
    {
        if(!reversedTeleport)
        {
            yield return new WaitForSeconds(teleportDelayTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>())
        {
           // gameObject.ch
        }
    }
}
