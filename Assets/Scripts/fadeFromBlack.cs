using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fadeFromBlack : MonoBehaviour
{
    public float FadeSpeed = 2f;

    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        this.GetComponent<RectTransform>().localScale = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (img.color.a >= 0.05f)
        {
            img.color = Color.Lerp(img.color, Color.clear, FadeSpeed * Time.deltaTime);
        }
        else
        {
            img.color = Color.clear;
        }
    }
}
