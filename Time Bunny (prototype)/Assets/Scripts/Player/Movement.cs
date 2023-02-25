using UnityEngine;
public class Movement : MonoBehaviour
{
    //Starter
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float CntrlSpeed;
    [SerializeField] private float jumpForce;
   /* [Header("OnGround")]
    [SerializeField] private float groundDrag;
    [SerializeField] private float groundSpeed;
    [SerializeField] private float groundNormalSpeed;
    [SerializeField] private float groundRunSpeed;
    [SerializeField] private float groundCnrlSpeed;
    [Header("OnAir")]
    [SerializeField] private float airDrag;
    [SerializeField] private float airSpeed;
    [SerializeField] private float airNormalSpeed;
    [SerializeField] private float airRunSpeed;
    [SerializeField] private float airCntrlSpeed;

    [Header("Dash")]
    [SerializeField] private Dash dashScript;*/
    bool canJump = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float rotationX = Input.GetAxis("Mouse X");
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Rotate(0, rotationX, 0);
        if (moveX != 0 || moveY != 0)
        {
            rb.AddForce(moveX * transform.right * speed);
            rb.AddForce(moveY * transform.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = CntrlSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = normalSpeed;
        }

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -speed, speed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;         
        }
    }
}
