using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvSensorScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Lazers;
    [SerializeField] private bool IsInverted;
    [SerializeField] private bool[] IsLazersActive;
    public bool lazerActivate;
    void Start()
    {
        for(int i = 0; i < Lazers.Length; i++)
        {
            Lazers[i].SetActive(IsLazersActive[i]);
        }
    }

    void Update()
    {
        if (lazerActivate)
            LazerActivating();
    }
    private void LazerActivating()
    {
        lazerActivate = false;
    }
}
