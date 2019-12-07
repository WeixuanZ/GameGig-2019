using UnityEngine;
using UnityEngine.UI;

public class fadeFromBlack : MonoBehaviour
{
    public float FadeSpeed = 2f;

    private Image img;

    void Start()
    {
        img = this.GetComponent<Image>();
        img.color = Color.black;

        SceneData datapass = GameObject.FindGameObjectWithTag("persistent").GetComponent<SceneData>();
        AudioSource Music = datapass.GetComponent<AudioSource>();
        if (!Music.isPlaying)
            Music.Play();
    }

    void Update()
    {
        if (img.color.a >= 0.50f)
            Cursor.visible = true;

        if (img.color.a >= 0.05f)
        {
            img.color = Color.Lerp(img.color, Color.clear, FadeSpeed * Time.deltaTime);
        }
        else
        {
            img.color = Color.clear;
            this.enabled = false;
        }
    }
}
