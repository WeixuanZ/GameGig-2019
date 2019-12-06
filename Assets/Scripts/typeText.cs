using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeText : MonoBehaviour
{
    public getScores scoreDrawer;
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

                if (currentString.Length > 9)
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
                scoreDrawer.UpdateScoreboard();
            }
        }
    }
}
