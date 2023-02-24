using UnityEngine;
public class Telekinesis : MonoBehaviour
{
    [SerializeField] bool TelekinesGunIsTaken;
    [SerializeField] bool ItemTelekinesed;
    [SerializeField] float distance;
    [SerializeField] GameObject cam;
    Rigidbody HitRb;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, cam.transform.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("Telekinesible") && Input.GetKeyDown(KeyCode.T) && TelekinesGunIsTaken && !ItemTelekinesed)
            {
                ItemTelekinesed = true;
                HitRb = hit.transform.GetComponent<Rigidbody>();
                HitRb.isKinematic = true;
                HitRb.useGravity = false;
                hit.transform.parent = cam.transform;
            }
            if (hit.transform.CompareTag("Telekinesible") && Input.GetKeyUp(KeyCode.T) && TelekinesGunIsTaken && ItemTelekinesed)
            {
                ItemTelekinesed = false;
                HitRb = hit.transform.GetComponent<Rigidbody>();
                HitRb.isKinematic = false;
                HitRb.useGravity = true;
                hit.transform.parent = null;
            }
        }        
    }
}
