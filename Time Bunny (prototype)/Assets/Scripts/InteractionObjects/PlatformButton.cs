using UnityEngine;
public class PlatformButton : MonoBehaviour
{
    [SerializeField] private GameObject doorLeftPart;
    [SerializeField] private GameObject doorRightPart;

    private Quaternion OpenQuaternion = Quaternion.Euler(0, 90 ,0);
    private Quaternion CloseQuaternion = Quaternion.Euler(0,0,0);

    [SerializeField] private float RotationSpeed;

    [SerializeField] private Color HoverColor;

    private Renderer rend;
    private Color startColor;
    private bool Open;
    private bool needMove = true;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void Update()
    {
        if (Open)
        {
            doorRightPart.transform.rotation = Quaternion.Lerp(doorLeftPart.transform.rotation, OpenQuaternion, RotationSpeed * Time.deltaTime);
            doorLeftPart.transform.rotation = Quaternion.Lerp(doorLeftPart.transform.rotation, OpenQuaternion, RotationSpeed * Time.deltaTime);
        }
        else if (!Open)
        {
            doorRightPart.transform.rotation = Quaternion.Lerp(doorLeftPart.transform.rotation, CloseQuaternion, RotationSpeed * Time.deltaTime);
            doorLeftPart.transform.rotation = Quaternion.Lerp(doorLeftPart.transform.rotation, CloseQuaternion, RotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Telekinesible")
        {
            Open = true;
            rend.material.color = HoverColor;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Telekinesible")
        {
            Open = false;
            rend.material.color = startColor;
        }
    }
}
