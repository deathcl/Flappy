using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;
    public AudioClip audioclipFlap;
    public AudioClip audioclipHit;
    public AudioClip audioclipPoint;
    public AudioSource audioSource;

    private void Awake()
    {
        //generamos la instacia a si mismo para dejarla activa siempre y cuando no exista una anterior
        if (SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }
        else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudioPoint()
    {
        PlayAudioClip(audioclipPoint);
    }

    public void PlayAudioHit()
    {
        PlayAudioClip(audioclipHit);
    }

    public void PlayAudioFlap()
    {
        PlayAudioClip(audioclipFlap);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
