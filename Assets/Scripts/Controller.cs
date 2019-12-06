using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Camera camera;
    public GameObject bullet;

    public float innerRect;
    // Start is called before the first frame update
    void Start()
    {
        

        SpawnBullets();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnBullets()
    {
        Vector3 top = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 bottom = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        Instantiate(bullet, top, Quaternion.identity);
        Instantiate(bullet, bottom, Quaternion.identity);

        GeneratePath(top, bottom);
    }

    void GeneratePath(Vector3 top, Vector3 bottom)
    {
        Vector3 range = top - bottom;
        Vector3 offset = range*(1-innerRect)*Random.value;
        Vector3 point = top + offset + range* innerRect;

        Debug.Log(point);
    }
}
