using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdjust : MonoBehaviour
{
    //My screen aspect ratio
    private float widthREF = 22.60906f;
    private float heighthREF = 9.78807f;

    void Start()
    {
        Camera.main.aspect = widthREF / heighthREF;

        Time.timeScale = 1;
    }
}
