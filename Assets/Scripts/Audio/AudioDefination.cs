using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO playAudioEvent;
    public AudioClip audioClip;
    public bool playOnEnable;

    private bool isPlaying = false;

    private void OnEnable()
    {
        // if(playOnEnable)
        // {
        //     isPlaying = true;
        //     PlayAudioClip();
        // }
    }

    private void OnDisable()
    {
        isPlaying = false;
    }

    private void Update()
    {
        if(playOnEnable && !isPlaying)
        {
            isPlaying = true;
            PlayAudioClip();
        }
    }

    public void PlayAudioClip()
    {
        Debug.Log("AudioDefination: PlayAudioClip");
        playAudioEvent.RaiseEvent(audioClip);
    }

    public void PlayAudio()
    {
        PlayAudioClip();
    }
}
