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
        rend.material.color = HoverColor;
    }

    private void OnCollisionExit(Collision collision)
    {
        rend.material.color = startColor;
    }
}
