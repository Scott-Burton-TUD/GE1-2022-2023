using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public GameObject head;
    public GameObject tail;
    public GameObject fish;

    [Range(0.0f, 5.0f)]
    public float Frequency;

    public int HeadAmplitude;
    public int TailAmplitude;
    public int FishAmplitude;
    public float theta;
    
    void Update()
    {

        Frequency += theta * Time.deltaTime;
        float HeadMovement = Mathf.Sin(Frequency) * HeadAmplitude;
        float TailMovement = Mathf.Sin(Frequency) * TailAmplitude;
        float FishMovement = Mathf.Sin(Frequency) * FishAmplitude;

        head.transform.localRotation = Quaternion.AngleAxis(HeadMovement, new Vector3(0, 0, 200));
        tail.transform.localRotation = Quaternion.AngleAxis(TailMovement, new Vector3(0, 0, 200));
        fish.transform.localRotation = Quaternion.AngleAxis(FishMovement, new Vector3(0, 0, 200));




    }
}