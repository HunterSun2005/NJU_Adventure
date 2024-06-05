using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    [Header("事件监听")]
    public PlayAudioEventSO FXEvent;

    public PlayAudioEventSO BGMEvent;

    [Header("组件")]
    public AudioSource BGMSource;

    public AudioSource FXSource;

    public Slider sliderBGM;

    public Slider sliderFX;

    private void OnEnable()
    {
        FXEvent.OnEventRaised += OnFXEvent;
        BGMEvent.OnEventRaised += OnBGMEvent;
    }

    private void OnDisable()
    {
        FXEvent.OnEventRaised -= OnFXEvent;
        BGMEvent.OnEventRaised -= OnBGMEvent;
    }

    private void OnFXEvent(AudioClip audioClip)
    {
        FXSource.clip = audioClip;
        FXSource.Play();
    }

    private void OnBGMEvent(AudioClip audioClip)
    {
        BGMSource.clip = audioClip;
        Debug.Log("AudioManager: OnBGMEvent");
        BGMSource.Play();
    }


    public void SetFXVolume(float volume)
    {
        FXSource.volume = volume;
    }

    public void SetBGMVolume(float volume)
    {
        BGMSource.volume = volume;
    }

    private void Update()
    {
        if (sliderBGM != null)
        {
            SetBGMVolume(sliderBGM.value);
        }
        if (sliderFX != null)
        {
            SetFXVolume(sliderFX.value);
        }
    } //实时更新音量
}
