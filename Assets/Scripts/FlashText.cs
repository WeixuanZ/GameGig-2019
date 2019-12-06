using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashText : MonoBehaviour
{
    public bool enabled = false;

    float flashSpeed = 4;
    TextMeshProUGUI texMesh;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        texMesh = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled) {
            texMesh.color = new Color(0, 1, 1, Mathf.Sin(currentTime * flashSpeed) + 1.1f);
            currentTime += Time.deltaTime;
        }
    }
}
