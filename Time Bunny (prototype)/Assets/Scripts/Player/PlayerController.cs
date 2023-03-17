using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject telekinesScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TelekinesGun")
        {
            telekinesScript.GetComponent<Telekinesis>().TelekinesGunIsTaken = true;
            Destroy(collision.gameObject);
        }
    }
}