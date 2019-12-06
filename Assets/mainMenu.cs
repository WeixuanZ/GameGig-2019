using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("persistent").GetComponent<SceneData>().fromGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
