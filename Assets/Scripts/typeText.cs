using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<InputField>().onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        this.GetComponent<InputField>().ActivateInputField();
        this.GetComponent<InputField>().Select();
        this.GetComponent<InputField>().navigation 
    }


    public void ValueChangeCheck()
    {
        Debug.Log("Hello");
    }
}
