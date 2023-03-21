using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Telekinesis telekinesis;
    [SerializeField] private float Speed;
    [SerializeField] private float SpeedUp;
    private bool canDash = true;

    [Header("Audio")]
    [SerializeField] private AudioSource DashAudioSource;
    [SerializeField] private AudioClip dash;
    private bool canPlayDash = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canDash && telekinesis.isGrabbing == false)
        {
            canDash = false;
            Invoke("CanDash", 3f);
            if (canPlayDash)
                StartCoroutine(DashAudio());
            rb.AddForce(Vector3.Normalize(new Vector3(rb.velocity.x, 0, rb.velocity.z)) * Speed, ForceMode.Impulse);
            rb.AddForce(Vector3.Normalize(new Vector3(0, 5, 0)) * SpeedUp, ForceMode.Impulse);
        }
    }

    IEnumerator DashAudio()
    {
        canPlayDash = false;
        DashAudioSource.clip = dash;
        DashAudioSource.Play();
        yield return new WaitForSeconds(3);
        canPlayDash = true;
    }

    void CanDash()
    {
        canDash = true;
    }
}
