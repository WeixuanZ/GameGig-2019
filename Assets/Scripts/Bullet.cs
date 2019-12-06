using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Controller controller;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(new Vector3(0, 0, 1), (Mathf.Atan(direction.y / direction.x)*360)/(2*Mathf.PI));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * controller.bulletSpeed * Time.deltaTime;
    }
}
