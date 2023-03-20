using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TilemapOrientation : MonoBehaviour
{
    public GameObject portraitObject;
    public GameObject landscapeObject;
    public float fadeDuration = 1f;
    private bool isPortrait = true;
    private bool isFading = false;
    private Camera mainCamera;
    public float cameraSizePortrait = 10f;
    public float cameraSizeLandscape = 15f;
    public Image blackScreen;
    private bool isTransitioning = false;

    void Start()
    {
        mainCamera = Camera.main;
        blackScreen.gameObject.SetActive(true);

        // Get the Image component and set the alpha to 1.0f (fully opaque)
        Image image = blackScreen.GetComponent<Image>();
        Color color = image.color;
        color.a = 1.0f;
        image.color = color;

        // Start with a fade-in effect
        StartCoroutine(FadeIn(blackScreen));
    }

    IEnumerator FadeIn(Image image)
    {
        isTransitioning = true;
        image.gameObject.SetActive(true);

        image.canvasRenderer.SetAlpha(0f);

        image.CrossFadeAlpha(1f, fadeDuration, false);

        yield return new WaitForSeconds(fadeDuration);
        Debug.Log("in");

        isTransitioning = false;
    }

    IEnumerator FadeOut(Image image)
    {
        isTransitioning = true;
        image.CrossFadeAlpha(0f, fadeDuration, false);

        yield return new WaitForSeconds(fadeDuration);

        image.gameObject.SetActive(false);
        Debug.Log("fade out");

        isTransitioning = false;
    }


    private void Update()
    {
        Debug.Log("Current orientation: " + Screen.orientation);

        if (!isTransitioning && Input.deviceOrientation == DeviceOrientation.Portrait && !isPortrait)
        {
            isPortrait = true;
            StartCoroutine(FadeOut(blackScreen));
            portraitObject.SetActive(true);
            landscapeObject.SetActive(false);
            Debug.Log("Portrait Object: " + portraitObject.name);
            mainCamera.orthographicSize = cameraSizePortrait;
        }
        else if (!isTransitioning && Input.deviceOrientation == DeviceOrientation.LandscapeLeft && isPortrait)
        {
            isPortrait = false;
            //StartCoroutine(FadeIn(blackScreen));
            portraitObject.SetActive(false);
            landscapeObject.SetActive(true);
            Debug.Log("Landscape Object: " + landscapeObject.name);
            mainCamera.orthographicSize = cameraSizeLandscape;
        }
    }
}
