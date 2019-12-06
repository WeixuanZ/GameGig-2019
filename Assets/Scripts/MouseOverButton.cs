using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ParticleSystem system;

    void Start()
    {
        system.Stop();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        system.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        system.Stop();
    }
}
