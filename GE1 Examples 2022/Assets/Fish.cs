using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Transform head;
    public Transform tail;
    [Range(0.0f, 5.0f)]
    public float frequency = 0.5f;
    public float headAmplitude = 40;
    public float tailAmplitude = 60;
    public float theta = 0;

    void Start()
    {
        theta = 0;
    }

    void Update()
    {
        
    }
}
