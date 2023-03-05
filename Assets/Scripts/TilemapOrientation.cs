using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OrientationManager : MonoBehaviour
{
    public GameObject portraitObject;
    public GameObject landscapeObject;

    private void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            portraitObject.SetActive(true);
            landscapeObject.SetActive(false);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            portraitObject.SetActive(false);
            landscapeObject.SetActive(true);
        }
    }
}
