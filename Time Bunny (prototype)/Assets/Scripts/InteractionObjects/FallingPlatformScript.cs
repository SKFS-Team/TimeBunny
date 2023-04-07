using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    [SerializeField] private Vector3 posStart;
    [SerializeField] private Vector3 posEnd;
    private Vector3 move;
    private bool isMoved;
    private int counter;
    [SerializeField] private int ticks;
    [SerializeField] private float secounds;
    [SerializeField] private float secoundsDelayToRise;

    private void Start()
    {
        move = (posEnd - posStart) / ticks;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    IEnumerator PosBegin()
    {
        gameObject.transform.position = gameObject.transform.position + move;
        counter++;
        yield return new WaitForSeconds(secounds / ticks);
        if(counter < ticks)
        {
            StartCoroutine(PosBegin());
        }
        else if (counter == ticks)
        {
            isMoved = true;
            StartCoroutine(MoveSwitch());
        }
    }
    IEnumerator PosEnd()
    {
        gameObject.transform.position = gameObject.transform.position - move;
        counter--;
        yield return new WaitForSeconds(secounds / ticks);
        if (counter > 0)
        {
            StartCoroutine(PosBegin());
        }
        else if (counter == 0)
        {
            StartCoroutine(PosEnd());
        }
    }
    IEnumerator MoveSwitch()
    {
        yield return new WaitForSeconds(secoundsDelayToRise);
        if (isMoved) { StartCoroutine(PosEnd()); }
        else { StartCoroutine(PosBegin()); }
    }
}
