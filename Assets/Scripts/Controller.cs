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

    public float bulletSpeed = 0;
    float countdown;
    bool bulletsSpawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(bulletsSpawned)
        {
            countdown -= Time.deltaTime;
            if(countdown < 0)
            {
                return;
            }
            if(countdown < 0.2)
            {
                bulletSpeed = countdown*(1/0.2f);
            }
        }
        else
        {
            bulletSpeed = 5;
            bulletsSpawned = true;
            SpawnBullets(5);
            countdown = 0.5f;
        }
    }

    float SpeedCurve()
    {
        return -Mathf.Exp(2 * (countdown - 1)) + 2;
    }

    void SpawnBullets(int count)
    {
        Vector3 top = camera.ViewportToWorldPoint(new Vector3(1, 1, 10));
        Vector3 bottom = camera.ViewportToWorldPoint(new Vector3(0, 0, 10));

        for(int i=0; i<count; i++)
        {
            GeneratePath(top, bottom);
        }
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
        float lambda = leftDiff;
        if (Mathf.Abs(rightDiff) < Mathf.Abs(leftDiff))
        {
            lambda = rightDiff;
        }
        lambda *= 1.2f;
        generatedObj = Instantiate(bulletPre, direction * lambda + point1, Quaternion.identity);
        Bullet bulletScript = generatedObj.GetComponent<Bullet>();

        if ((direction * (lambda + 1) + point1).magnitude > (direction * lambda + point1).magnitude)
        {
            direction *= -1;
        }
        bulletScript.controller = this;
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
