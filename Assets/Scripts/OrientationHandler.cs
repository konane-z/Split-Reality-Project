using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class OrientationHandler : MonoBehaviour
{
    public GameObject portraitObject;
    public GameObject landscapeObject;
    private Camera mainCamera;
    public float cameraSizePortrait = 10f;
    public float cameraSizeLandscape = 15f;

    void Start()
    {
        mainCamera = Camera.main;
    }

   


    private void Update()
    {
       

        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            portraitObject.SetActive(true);
            landscapeObject.SetActive(false);
            mainCamera.orthographicSize = cameraSizePortrait;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
           
            portraitObject.SetActive(false);
            landscapeObject.SetActive(true);
            mainCamera.orthographicSize = cameraSizeLandscape;
        }
    }
}