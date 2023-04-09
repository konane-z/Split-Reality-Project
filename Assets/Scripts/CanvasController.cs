using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvasObject;
    private DeviceOrientation originalOrientation;
    private bool canvasActive = false;
    public float displayTime = 2.0f;

    void Start()
    {
        originalOrientation = Input.deviceOrientation;
    }

    void Update()
    {
        if (Input.deviceOrientation != originalOrientation && !canvasActive)
        {
            canvasObject.SetActive(true);
            Invoke("DisableCanvas", displayTime);
            canvasActive = true;
        }
    }

    void DisableCanvas()
    {
        canvasObject.SetActive(false);
        canvasActive = false;
    }
}



