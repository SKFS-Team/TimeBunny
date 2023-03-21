using UnityEngine;
public class Movement : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float CntrlSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float climbSpeed;

    [Header("Limites")]
    [SerializeField] private float maxCtrlVelocity;

    private bool isClimbing;
    private bool isNearClimbWall;

    [Header("Audio")]
    [SerializeField] private AudioSource PlayerAudioSource;
    [SerializeField] private AudioClip Walk;
    private bool CanPLayWalk = true;
    private bool groud = true;

    [Header("SpeedSensor")]
    [SerializeField] private float maxSpeed;


    bool canJump = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Audio();

        float rotationX = Input.GetAxis("Mouse X");
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Rotate(0, rotationX, 0);
        if ((moveX != 0 || moveY != 0) && !isClimbing)
        {
            rb.AddForce(moveX * transform.right * speed * Time.deltaTime);
            rb.AddForce(moveY * transform.forward * speed * Time.deltaTime);          
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
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxCtrlVelocity, maxCtrlVelocity), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -maxCtrlVelocity, maxCtrlVelocity));
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
        groud = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        groud = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ClimbWall")
        {
            isNearClimbWall = true;
        }
        if (other.tag == "SensorSpeed" && rb.velocity.x > maxSpeed || rb.velocity.z > maxSpeed)
        {
            Destroy(gameObject);
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

    void Audio()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && groud) 
        {
            PlayerAudioSource.clip = Walk;
            PlayerAudioSource.loop = true;
            if (CanPLayWalk)
            {
                PlayerAudioSource.Play();           
                CanPLayWalk = false;
            }
        }
        else if (!groud || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            PlayerAudioSource.Stop();
            CanPLayWalk = true;
        }
    }
}
