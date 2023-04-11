using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isHeld = false;
    public GameObject newTorch;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isHeld = true;
            gameObject.SetActive(false);
            newTorch.SetActive(true); 
        }
    }
}

