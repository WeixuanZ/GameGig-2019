using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float brightness;

    bool hasRequest = false;
    float timeSinceRequest = 0;
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().color = new Color(brightness, brightness, brightness, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasRequest)
        {
            timeSinceRequest += Time.deltaTime * speed;
            this.GetComponent<Text>().color = new Color(brightness, brightness, brightness, Mathf.Sin(timeSinceRequest));
            if (timeSinceRequest > Mathf.PI)
            {
                hasRequest = false;
                this.GetComponent<Text>().color = new Color(brightness, brightness, brightness, 0);
            }
        }
    }

    public void ShowText(string text, float speed)
    {
        this.speed = speed;
        hasRequest = true;
        timeSinceRequest = 0;
        this.GetComponent<Text>().text = text;
        this.GetComponent<Text>().color = new Color(brightness, brightness, brightness, 0);
    }
}
