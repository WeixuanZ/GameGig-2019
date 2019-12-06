using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<InputField>().onValueChanged.AddListener(ValueChangeCheck);
        this.GetComponent<InputField>().ActivateInputField();
        this.GetComponent<InputField>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ValueChangeCheck(string input)
    {
        Debug.Log("Hello");
    }
}
