using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_input : MonoBehaviour
{
    public float Speed = 10;
    public Rigidbody2D Body;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dr = new Vector3(h, v, 0);
        dr = dr.normalized * Speed * Time.deltaTime;

        Body.MovePosition(Body.transform.position + dr);
    }
}
