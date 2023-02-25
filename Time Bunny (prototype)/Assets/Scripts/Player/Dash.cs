using UnityEngine;
public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator CameraAnimator;
    public float Speed;
    private bool canDash = true;
    private void Update()
    {
        if(Input.GetMouseButtonDown(2) && canDash)
        {
            canDash = false;
            CameraAnimator.SetTrigger("InDash");
            Invoke("CanDash", 1f);
            rb.AddForce(Vector3.Normalize(new Vector3(rb.velocity.x, 0, rb.velocity.z)) * Speed, ForceMode.Impulse);
        }
    }

    void CanDash()
    {
        canDash = true;
    }
}