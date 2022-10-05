using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{

    public Material rainbow;
    public Color32[] colors;

    void Start()
    {
        rainbow = transform.GetComponent<MeshRenderer>().material;
        colors = new Color32[7]
        {
            new Color32(255, 0, 0, 255),
            new Color32(255, 165, 0, 255),
            new Color32(255, 255, 0, 255),
            new Color32(0, 255, 0, 255),
            new Color32(0, 0, 255, 255),
            new Color32(75, 0, 130, 255),
            new Color32(238, 130, 238, 255),

        };
        StartCoroutine(cycle());
    }
    
    public IEnumerator cycle()
    {
        int i = 0;

        while (true)
        {
            for (float interpolant = 0f; interpolant < 1f; interpolant += 0.001f)
            {
                rainbow.color = Color.Lerp(colors[i % 7], colors[(i + 1) % 7], interpolant);
                yield return null;
            }
            i++;
        }


    }
}