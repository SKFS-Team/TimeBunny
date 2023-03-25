using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorLazerScript : MonoBehaviour
{
    [SerializeField] private SensorTarget sensrTargt;
    [SerializeField] private string TagSeek;
    [SerializeField] private string[] Functions;
    [SerializeField] private Vector3[] funcStart;
    [SerializeField] private Vector3[] funcEnd;
    [SerializeField] private float[] funcSec;
    [SerializeField] private int[] funcTicks;
    [SerializeField] private bool isSingleUse;
    private bool isUsed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagSeek)
        {
            if(!isUsed)
                LazerFunc();
        }
    }
    void LazerFunc()
    {
        sensrTargt.funcActivate = true;
        if(isSingleUse)
            isUsed = true;
    }
    void ExtraFunc()
    {
        sensrTargt.sensLazScript = gameObject.GetComponent<SensorLazerScript>();
        sensrTargt.sensLazVectorBegin = funcStart[0];
        sensrTargt.sensLazVectorEnd = funcEnd[0];
        sensrTargt.sensLazTicks = funcTicks[0];
        sensrTargt.sensLazSec = funcSec[0];
    }
}
