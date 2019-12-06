﻿using UnityEngine;
using UnityEngine.UI;

public class fadeFromBlack : MonoBehaviour
{
    public float FadeSpeed = 2f;

    private Image img;

    void Start()
    {
        img = this.GetComponent<Image>();
        img.color = Color.black;
    }

    void Update()
    {
        if (img.color.a >= 0.05f)
        {
            img.color = Color.Lerp(img.color, Color.clear, FadeSpeed * Time.deltaTime);
        }
        else
        {
            img.color = Color.clear;
            Cursor.visible = true;
            this.enabled = false;
        }
    }
}
