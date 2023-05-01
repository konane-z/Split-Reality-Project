using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isHeld = false;
    public GameObject newKey;
    public GameObject oldItem;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isHeld = true;
            gameObject.SetActive(false);
            oldItem.SetActive(false);
            newKey.SetActive(true);
        }
    }
}
