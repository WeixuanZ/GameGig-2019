using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeText : MonoBehaviour
{
    public GetScores scoreDrawer;
    public string currentString = "";
    // Start is called before the first frame update

    void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                if (vKey.ToString() == "Backspace" && currentString.Length > 0)
                {
                    currentString = currentString.Substring(0, currentString.Length - 1);
                }

                if (currentString.Length > 8)
                {
                    continue;
                }
                if(vKey.ToString().Length == 1)
                {
                    currentString += vKey.ToString();
                }
                if(vKey.ToString() == "Space")
                {
                    currentString += " ";
                }
                if(vKey.ToString() == "Return")
                {
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
                scoreDrawer.UpdateScoreboard();
            }
        }
    }
}
