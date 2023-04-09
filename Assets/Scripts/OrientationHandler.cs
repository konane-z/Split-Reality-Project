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
    private ScreenOrientation previousOrientation;

    void Start()
    {
        mainCamera = Camera.main;
        previousOrientation = Screen.orientation;
    }

    private void Update()
    {
        if (Screen.orientation != previousOrientation)
        {
            previousOrientation = Screen.orientation;

            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                portraitObject.SetActive(true);
                landscapeObject.SetActive(false);
                mainCamera.orthographicSize = cameraSizePortrait;
            }
            else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            {
                portraitObject.SetActive(false);
                landscapeObject.SetActive(true);
                mainCamera.orthographicSize = cameraSizeLandscape;
            }
        }
    }
}