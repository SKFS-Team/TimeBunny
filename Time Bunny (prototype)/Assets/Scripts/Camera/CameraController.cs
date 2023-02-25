using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensivity;
    private float CameraVerticalRotation;
    [SerializeField] private float minCameraRotation;
    [SerializeField] private float maxCameraRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float inputY = Input.GetAxis("Mouse Y") * mouseSensivity;

        CameraVerticalRotation -= inputY;
        CameraVerticalRotation = Mathf.Clamp(CameraVerticalRotation, minCameraRotation, maxCameraRotation);
        transform.localEulerAngles = Vector3.right * CameraVerticalRotation;
    }
}
