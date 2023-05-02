using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAudioTrigger : MonoBehaviour
{

    public AudioClip dayClip;
    public AudioClip nightClip;
    public AudioClip menuClip;
    public AudioClip mushroomClip;
    public AudioClip mushroomChatter;
    public AudioSource audioSource;
    public AudioSource mushroomTalkClip;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = mushroomClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.active == false)
        {
            audioSource.Stop();
        }
    }

    void stopAllSounds()
    {
        audioSource.Stop();
    }
}
