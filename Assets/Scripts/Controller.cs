using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Camera camera;
    public GameObject bulletPre;
    public List<Bullet> bullets;

    public float difficulty;

    public float innerRect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBullets()
    {
        Vector3 top = camera.ViewportToWorldPoint(new Vector3(1, 1, 10));
        Vector3 bottom = camera.ViewportToWorldPoint(new Vector3(0, 0, 10));

        GeneratePath(top, bottom);
    }

    void GeneratePath(Vector3 top, Vector3 bottom)
    {
        Vector3 range = top - bottom;
        Vector3 point1 = bottom + GenerateRandomOffset(range) + range*(1-innerRect)*0.5f;
        Vector3 point2 = bottom + GenerateRandomOffset(range) + range * (1 - innerRect) * 0.5f;

        GameObject generatedObj;
        Vector3 direction = point1 - point2;
        direction.Normalize();
        //Approch from top, right or bottom left
        Vector3 refPoint = Random.value < 0.5 ? top : bottom;

        Vector3 diff = refPoint - point1;
        float rightDiff = diff.x / direction.x;
        float leftDiff = diff.y / direction.y;
        float lamdba = leftDiff;
        if (Mathf.Abs(rightDiff) < Mathf.Abs(leftDiff))
        {
            lamdba = rightDiff;
        }
        lamdba *= 1.1f;
        if((direction * (lamdba+1) + point1).magnitude > (direction * lamdba + point1).magnitude)
        {
            lamdba *= -1;
        }
        generatedObj = Instantiate(bulletPre, direction * lamdba + point1, Quaternion.identity);
        Bullet bulletScript = generatedObj.GetComponent<Bullet>();

        bulletScript.direction = direction;
        bullets.Add(bulletScript);
    }
    Vector3 GenerateRandomOffset(Vector3 range)
    {
        Vector3 offset = range * innerRect;
        offset.x *= Random.value;
        offset.y *= Random.value;
        return offset;
    }
}
