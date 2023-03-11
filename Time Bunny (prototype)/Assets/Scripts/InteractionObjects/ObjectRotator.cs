using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRotator : MonoBehaviour
{
    [Header("PlayerScripts")]
    [Space(5)]

    [SerializeField] private Movement movement;
    [SerializeField] private CameraController cameraController;

    [Header("Attributes")]
    [Space(5)]

    [SerializeField] private GameObject GameObjectToRotate;

    [SerializeField] private float rotationSpeed = 5.0f;
    public float needEnergy;
    public bool isRotating = false;

    [Header("UI")]
    [Space(5)]
    [SerializeField] private Slider FuelSlider;

    private float currentAngle = 0.0f;


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
            needEnergy -= Time.deltaTime * 5;
            FuelSlider.value = needEnergy;
        }
    }

    void OnMouseDown()
    {
        if (needEnergy > 0)
        {
            isRotating = true;

            movement.enabled = false;
            cameraController.enabled = false;

            FuelSlider.gameObject.SetActive(true);
        }
    }

    void OnMouseUp()
    {
        isRotating = false;

        movement.enabled = true;
        cameraController.enabled = true;

        FuelSlider.gameObject.SetActive(false);
    }
}
