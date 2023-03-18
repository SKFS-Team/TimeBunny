using UnityEngine;
public class JumpPad : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerRb.AddForce(gameObject.transform.forward * forceForward * Time.deltaTime, ForceMode.Impulse);
            playerRb.AddForce(Vector3.up * forceUp * Time.deltaTime, ForceMode.Impulse);
        }  
    }
}
