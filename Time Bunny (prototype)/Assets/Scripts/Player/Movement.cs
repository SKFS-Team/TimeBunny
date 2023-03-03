using UnityEngine;
public class Movement : MonoBehaviour
{
    //Starter
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float CntrlSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isClimbing;
    [SerializeField] private bool isNearClimbWall;
    [SerializeField] private float climbSpeed;
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
        if ((moveX != 0 || moveY != 0) && !isClimbing)
        {
            rb.AddForce(moveX * transform.right * speed);
            rb.AddForce(moveY * transform.forward * speed);
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -speed, speed));
        }
        if (Input.GetKey(KeyCode.W) && isClimbing)
        {
            rb.AddForce(Vector3.up * climbSpeed);
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -climbSpeed, climbSpeed), rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.S) && isClimbing)
        {
            rb.AddForce(Vector3.down * climbSpeed);
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -climbSpeed, climbSpeed), rb.velocity.z);
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W)) && isClimbing)
        {
            Invoke("VelocityZero", .1f);
        }

        if (Input.GetKeyDown(KeyCode.C) && isNearClimbWall && !isClimbing)
        {
            MovementSwitch(true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && isClimbing)
        {
            MovementSwitch(false);
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
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = CntrlSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = normalSpeed;
        }

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -speed, speed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ClimbWall")
        {
            isNearClimbWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MovementSwitch(false);
        isNearClimbWall = false;
    }
    void MovementSwitch(bool Bool)
    {
        isClimbing = Bool;
        rb.useGravity = !Bool;
    }
    void VelocityZero()
    {
        rb.velocity = Vector3.zero;
    }
}
