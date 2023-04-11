using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines = new string[] {
    "Hello there!",
    "Are you stuck here?",
    "The forest can be tricky to navigate. If you're having trouble, try changing the orientation of your phone.",
    "Just be carefull, the dark can hide a lot of evil creatures",
    "I've heard there are some hidden treasures there. Like a key to open the gate or a torch to keep you safe.",
    "Good luck on your adventures and visit me on your next adventure for more information!"
};
    int currentIndex = 0;

    void Start()
    {
        StartCoroutine(AnimateText(dialogueLines[currentIndex]));
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            currentIndex++;
            if (currentIndex < dialogueLines.Length)
            {
                StartCoroutine(AnimateText(dialogueLines[currentIndex]));
            }
        }
    }

    IEnumerator AnimateText(string text)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f); // Adjust this value to change the speed of the animation
        }
    }
}
