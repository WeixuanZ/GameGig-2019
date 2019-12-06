using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public string Name = "";
    public int score = 0;
    public bool fromGame = false;

    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("persistent").Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
