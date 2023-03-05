using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    [SerializeField] private float grabDistance, grabSpeed, grabDelta;
    private bool isGrabbing = false;
    private Rigidbody grabbedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance))
            {
                if(hit.collider.TryGetComponent<Rigidbody>(out grabbedObject))
                {
                    grabbedObject.useGravity = false;
                    grabbedObject.drag = 10f;
                    isGrabbing = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && grabbedObject)
        {
            grabbedObject.useGravity = true;
            grabbedObject.drag = 1f;
            isGrabbing = false;
        }
    }

    void FixedUpdate()
    {
        if (isGrabbing)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = grabDistance;
            Vector3 targetPosition = transform.position + (Camera.main.transform.forward * grabDistance);
                //Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height/2));
            Vector3 direction = targetPosition - grabbedObject.transform.position;
            if(Vector3.Distance(targetPosition, grabbedObject.transform.position) > grabDelta)
                grabbedObject.velocity = direction.normalized * grabSpeed;
        }
    }
}