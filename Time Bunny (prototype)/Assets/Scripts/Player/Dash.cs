using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float Speed = 15;
    private bool canDash = true;
    private void Update()
    {
        if(Input.GetMouseButtonDown(2) && canDash /*&& Camera.main.transform.rotation.x < 0 /*&& Camera.main.transform.rotation.x < -15*/)
        {
            canDash = false;
            Invoke("CanDash", 1f);
            rb.AddForce(Camera.main.transform.forward * Speed, ForceMode.Impulse);
        }
    }

    void CanDash()
    {
        canDash = true;
    }
}