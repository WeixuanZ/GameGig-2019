using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneData : MonoBehaviour
{
    public string lastName = "";
    public int lastScore = 0;

    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("persistent").Length > 1) {
            Destroy(this);
        }
    }
}
