using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    public bool TelekinesGunIsTaken;
    public bool ItemTelekinesed;
    public float distance;
    public GameObject cam;
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, cam.transform.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("Telekinesible") && Input.GetKeyDown(KeyCode.T) && TelekinesGunIsTaken && !ItemTelekinesed)
            {
                ItemTelekinesed = true;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.parent = cam.transform;
            }
            if (hit.transform.CompareTag("Telekinesible") && Input.GetKeyUp(KeyCode.T) && TelekinesGunIsTaken && ItemTelekinesed)
            {
                ItemTelekinesed = false;
                hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                hit.transform.GetComponent<Rigidbody>().useGravity = true;
                hit.transform.parent = null;
            }
        }
        
    }
}
