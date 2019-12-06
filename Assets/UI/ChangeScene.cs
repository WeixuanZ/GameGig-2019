using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string ChangeTo;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Transition);
    }

    void Transition()
    {
        if (ChangeTo == "Exit")
            Application.Quit();
        else
            SceneManager.LoadScene(this.ChangeTo, LoadSceneMode.Single);
    }
}
