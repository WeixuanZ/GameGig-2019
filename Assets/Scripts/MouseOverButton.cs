using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using TMPro;

public class MouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public AudioClip menuNoise;
    public AudioSource musicSource;


    void Start()
    {
        musicSource.clip = menuNoise;
        gameObject.GetComponent<Image>().color = new Color(0f, 255f, 255f, 0f);
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0f, 255f, 255f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        musicSource.Play();
        gameObject.GetComponent<Image>().color = new Color(0f, 255f, 255f, 1f);
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(0f, 255f, 255f, 0f);
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0f, 255f, 255f, 1f);
    }
}
