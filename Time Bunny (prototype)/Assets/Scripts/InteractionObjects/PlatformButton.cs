using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    [SerializeField] private Animator OpenGameObject;
    private Renderer rend;
    private Color startColor;
    [SerializeField] private Color HoverColor;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnCollisionStay(Collision collision)
    {
        OpenGameObject.SetBool("Open", true);
        rend.material.color = HoverColor;
    }

    private void OnCollisionExit(Collision collision)
    {
        OpenGameObject.SetBool("Open", false);
        rend.material.color = startColor;
    }
}
