using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    private bool playerOnPlatform = false;
    [SerializeField] float speed = 5;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

}
