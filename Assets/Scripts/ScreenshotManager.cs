using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    [SerializeField] private Settings settings;
    private string path;

    private void Start()
    {
        path = Application.persistentDataPath;
    }

    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot(path + "/Screenshot" + settings.screenshotNumber.ToString() + ".png");
        settings.screenshotNumber++;   
    }

}
