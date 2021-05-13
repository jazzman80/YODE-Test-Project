using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 1)]

public class Settings : ScriptableObject
{
    public float rotation;
    public float scale;
    public float screenshotNumber;

    public void RotateClockwise()
    {
        rotation += 90.0f;
    }

    public void RotateCounterClockwise()
    {
        rotation -= 90.0f;
    }

    public void ScaleUp()
    {
        scale += 0.01f;
        if (scale > 0.5f) scale = 0.5f;
    }

    public void ScaleDown()
    {
        scale -= 0.01f;
        if (scale < 0.02) scale = 0.02f;
    }
}
