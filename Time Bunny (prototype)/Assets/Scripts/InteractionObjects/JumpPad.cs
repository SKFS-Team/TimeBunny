using UnityEngine;
public class JumpPad : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    private float force;
    [SerializeField] private float forceUp;
    [SerializeField] private float forceForward;
    public bool NeedUp = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (NeedUp)
            {
                case true:
                    force = forceUp;
                    playerRb.AddForce(Vector3.up * force, ForceMode.Impulse);
                    break;
                case false:
                    force = forceForward;
                    playerRb.AddForce(Vector3.forward * force, ForceMode.Impulse);
                    break;
            }
        }  
    }
}
