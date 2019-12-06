using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeToWhite : MonoBehaviour
{
    public float FadeSpeed = 2f;

    private TextMeshProUGUI Text;

    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
        Text.color = Color.clear;
    }

    void Update()
    {
        if (Text.color.a <= 0.95f)
        {
            Text.color = Color.Lerp(Text.color, Color.white, FadeSpeed * Time.deltaTime);
        }
        else
        {
            Text.color = Color.white;
            enabled = false;
        }
    }
}
