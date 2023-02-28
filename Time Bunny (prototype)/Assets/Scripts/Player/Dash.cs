using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] private float SpeedUp;
    private bool canDash = true;
    private bool canDashUp = true;
    public bool ground = true;
    private void Update()
    {
        if(Input.GetMouseButtonDown(2) && canDash /*&& Camera.main.transform.rotation.x < 0 /*&& Camera.main.transform.rotation.x < -15*/)
        {
            canDash = false;
            Invoke("CanDash", 1f);
            rb.AddForce(Vector3.Normalize(new Vector3(rb.velocity.x, 0, rb.velocity.z)) * Speed, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(1) && canDashUp && ground)
        {
            canDashUp = false;
            Invoke("CanDashUp", 1f);
            rb.AddForce(Vector3.Normalize(new Vector3(0, 5, 0)) * SpeedUp, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        ground = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        ground = false;
    }

    void CanDash()
    {
        canDash = true;
    }

    void CanDashUp()
    {
        canDashUp = true;
    }
}