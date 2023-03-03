using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float Speed;
    private bool canDash = true;
    private void Update()
    {
        if(Input.GetMouseButtonDown(2) && canDash /*&& Camera.main.transform.rotation.x < 0 /*&& Camera.main.transform.rotation.x < -15*/)
        {
            canDash = false;
            Invoke("CanDash", 1f);
            rb.AddForce(Vector3.Normalize(new Vector3(rb.velocity.x, 0, rb.velocity.z)) * Speed, ForceMode.Impulse);
        }
    }

    void CanDash()
    {
        canDash = true;
    }
}