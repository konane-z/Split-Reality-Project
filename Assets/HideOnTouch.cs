using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HideOnTouch : MonoBehaviour
{
    // Reference to the image you want to hide
    public Image imageToHide;

    void Update()
    {
        // Check if the screen has been touched
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on the image
            if (RectTransformUtility.RectangleContainsScreenPoint(imageToHide.rectTransform, touch.position))
            {
                // Hide the image
                imageToHide.enabled = false;
            }
        }
    }
}

