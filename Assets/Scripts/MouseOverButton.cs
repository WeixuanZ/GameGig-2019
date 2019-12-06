using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class MouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ParticleSystem system;
    public AudioClip menuNoise;
    public AudioSource musicSource;

    void Start()
    {
        system.Stop();
        musicSource.clip = menuNoise;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        system.Play();
        musicSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        system.Stop();
    }
}
