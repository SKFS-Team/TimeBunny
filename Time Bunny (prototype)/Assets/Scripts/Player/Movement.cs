using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float CntrlSpeed;
    public float jumpForce;
    bool canJump = true;

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

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -speed, speed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -speed, speed));

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = CntrlSpeed;
        }
        else
        {
            speed = normalSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
