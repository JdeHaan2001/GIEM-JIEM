using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundEmitter))]
public class SoundEmitter : MonoBehaviour
{
    public AudioSource audioSource { get; private set; }
    public AudioClip audioClip { get; private set; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Playing Sound");
        }
    }
}
