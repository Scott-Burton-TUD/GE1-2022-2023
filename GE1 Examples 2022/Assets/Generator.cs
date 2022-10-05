﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 4;
    public GameObject color;
    public GameObject prefab;
    public int numberofObejcts = 100;

    public float radius = 20f;

    void Start()
    {
        SpawnObjects();
        Loop();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberofObejcts; i++)
        {
            float angle = i * Mathf.PI * 2 / numberofObejcts;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, z, 0);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(prefab, pos, rot);
        }
    }

    void Loop()
    {
        for (int x = 0; x < loops; x++)
        {
            radius = radius - 1;
            numberofObejcts = numberofObejcts - 5;
            SpawnObjects();
        }
    }
}