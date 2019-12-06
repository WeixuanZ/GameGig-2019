using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public float FadeSpeed = 2f;

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;

        GetComponent<RectTransform>().localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (img.color.a <= 0.95f)
        {
            img.color = Color.Lerp(img.color, Color.black, FadeSpeed * Time.deltaTime);
        }
        else
        {
            img.color = Color.black;
            enabled = false;
        }
    }
}
