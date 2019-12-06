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
        SceneManager.LoadScene(this.ChangeTo, LoadSceneMode.Single);
    }
}
