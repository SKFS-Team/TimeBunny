using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Telekinesis telekinesis;
    [SerializeField] private float Speed;
    [SerializeField] private float SpeedUp;
    private bool canDash = true;
    private bool canDashUp = true;
    private void Update()
    {
        if (Input.GetMouseButtonDown(2) && canDash && telekinesis.isGrabbing == false)
        {
            canDash = false;
            Invoke("CanDash", 1f);
            rb.AddForce(Vector3.Normalize(new Vector3(rb.velocity.x, 0, rb.velocity.z)) * Speed, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(1) && canDashUp && telekinesis.isGrabbing == false)
        {
            canDashUp = false;
            rb.AddForce(Vector3.Normalize(new Vector3(0,5,0)) * SpeedUp, ForceMode.Impulse);
        }
    }

    void CanDash()
    {
        canDash = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        canDashUp = true;
    }
}
