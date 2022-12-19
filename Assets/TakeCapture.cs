using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCapture : MonoBehaviour
{
    int captureNumber = 0;

    public void Capture()
    {
            ScreenCapture.CaptureScreenshot($"ScreenCapture{captureNumber}.png", 4);
            captureNumber++;
    }
}
