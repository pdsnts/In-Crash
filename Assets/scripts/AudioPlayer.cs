using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {

    }

    public void Play()
    {
        audioSource.Play();
        audioSource.PlayOneShot(clip);
    }
}

