using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simple implementation of rainbow-colored object over time
//Cycles through colors as follows:
//White -> Yellow -> Red -> Black -> Blue -> Cyan -> White
//This example uses a cube as an example
public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;
    private float red;
    private float green;
    private float blue;
    private float colorInterval;
    private bool whiteToBlack;
    Color baseColor;
    void Start()
    {
        red = 1.0f;
        blue = 1.0f;
        green = 1.0f;
        colorInterval = 0.005f; //Change this to a speed of your liking
        whiteToBlack = true;
        material = Renderer.material;
        baseColor = new Color(red, green, blue, 0.4f);
        material.color = baseColor;
    }
    void Update()
    {
        if (whiteToBlack)
        {
            if (blue > 0.0f)
                decreaseBlue();
            else if (green > 0.0f)
                decreaseGreen();
            else if (red > 0.0f)
                decreaseRed();
            else
                whiteToBlack = false;
        }
        if (!whiteToBlack)
        {
            if (blue < 1.0f)
                increaseBlue();
            else if (green < 1.0f)
                increaseGreen();
            else if (red < 1.0f)
                increaseRed();
            else
                whiteToBlack = true;
        }
        material.color = new Color(red, green, blue, 0.4f);
    }
    void decreaseRed()
    {
        red -= colorInterval;
    }
    void decreaseGreen()
    {
        green -= colorInterval;
    }
    void decreaseBlue()
    {
        blue -= colorInterval;
    }
    void increaseRed()
    {
        red += colorInterval;
    }
    void increaseGreen()
    {
        green += colorInterval;
    }
    void increaseBlue()
    {
        blue += colorInterval;
    }
}