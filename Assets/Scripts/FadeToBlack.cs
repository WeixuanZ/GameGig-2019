using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

            //Load correct scene
            StartCoroutine(LoadScoreboard());
        }
    }

    IEnumerator LoadScoreboard()
    {
        yield return new WaitForSeconds(0.5);
        SceneManager.LoadScene("Scoreboard", LoadSceneMode.Single);
    }
}
