using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private GameObject GameObjectToRotate;

    [SerializeField] private float rotationSpeed = 5.0f;
    public float needEnergy;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private float currentAngle = 0.0f;

    void Start()
    {
        targetRotation = GameObjectToRotate.transform.rotation;
    }

    void Update()
    {
        if (isRotating && needEnergy > 0)
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            GameObjectToRotate.transform.rotation = Quaternion.Euler(0.0f, currentAngle, 0.0f);
            if (currentAngle >= 360.0f)
            {
                currentAngle = 0.0f;
            }
            needEnergy -= Time.deltaTime; 
        }
    }

    void OnMouseDown()
    {
        if (needEnergy > 0)
        {
            isRotating = true;
        }
    }

    void OnMouseUp()
    {
        isRotating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.gameObject.CompareTag("Lazer"))
        {
            Debug.Log(1);
            needEnergy += 10.0f;
        }
    }
}
