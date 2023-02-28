using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private GameObject GameObjectToRotate;

    [SerializeField] private float rotationSpeed = 5.0f;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private float currentAngle = 0.0f;

    void Start()
    {
        targetRotation = GameObjectToRotate.transform.rotation;
    }

    void Update()
    {
        if (isRotating)
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            GameObjectToRotate.transform.rotation = Quaternion.Euler(0.0f, currentAngle, 0.0f);
            if (currentAngle >= 360.0f)
            {
                currentAngle = 0.0f;
            }
        }
    }

    void OnMouseDown()
    {
        isRotating = true;
    }

    void OnMouseUp()
    {
        isRotating = false;
    }
}
