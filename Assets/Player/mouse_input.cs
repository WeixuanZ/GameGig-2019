﻿using UnityEngine;

public class mouse_input : MonoBehaviour
{
    public Rigidbody2D Body;
    public BoxCollider2D Collider;
    public float Margin = 0.10f; // Percentage, for each edge of the screen

    private float Xmin;
    private float Xmax;
    private float Ymin;
    private float Ymax;

    void Start()
    {
        Vector2 Character = Collider.size;
        Vector3 World = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float MarginX = World.x * Margin;
        float MarginY = World.y * Margin;

        // Assumes the Camera is centered at the Origin
        Xmin = -World.x + MarginX + Character.x / 2;
        Xmax = -Xmin;
        Ymin = -World.y + MarginY + Character.y / 2;
        Ymax = -Ymin;
    }

    void Update()
    {
        Vector3 r = Input.mousePosition;

        // Input.mousePosition returns Pixels, we want Coordinates
        r = Camera.main.ScreenToWorldPoint(r);

        r.x = Mathf.Clamp(r.x, Xmin, Xmax);
        r.y = Mathf.Clamp(r.y, Ymin, Ymax);
        
        Body.MovePosition(r);
    }
}
