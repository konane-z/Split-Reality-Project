using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvasObject;
    private ScreenOrientation originalOrientation;
    private bool canvasActive = false;
    public float displayTime = 10.0f;
    public AudioClip menuClip;
    public AudioSource audioSource;

    void Start()
    {
        originalOrientation = Screen.orientation;
    }

    void Update()
    {
        if (Screen.orientation != originalOrientation && !canvasActive)
        {
            canvasObject.SetActive(true);
            Invoke("DisableCanvas", displayTime);
            canvasActive = true;
            StopSoundEffectMenuClip();
        }
    }

    void DisableCanvas()
    {
        canvasObject.SetActive(false);
        canvasActive = false;
        StopSoundEffectMenuClip();
    }

    public void StopSoundEffectMenuClip()
    {
        audioSource.clip = menuClip;
        audioSource.Stop();
    }
}



