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
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation.SetLookRotation(direction);
        this.transform.position += direction * controller.bulletSpeed * Time.deltaTime;
    }
}
