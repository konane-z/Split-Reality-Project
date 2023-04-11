using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvasOnTouch : MonoBehaviour
{
    private float lastTapTime;
    private void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2)
        {
            if (Time.time - lastTapTime < 0.5f)
            {
                gameObject.SetActive(false);
            }
            lastTapTime = Time.time;
        }
    }
}
