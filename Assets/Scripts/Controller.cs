using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Camera cam;
    public CountDown countdownUI;
    public GameObject bulletPre;
    public List<Bullet> bullets;

    public float difficulty;

    public float innerRect;

    public bool isDead = false;
    public float bulletSpeed = 0;
    public float bulletMoveTime;

    SceneData datapass;
    float timeSinceStart = 0;
    float countdown;
    int countdownNumber = 0;
    bool bulletsSpawned = false;

    string[] RewardText = {"Neat", "Nice", "Well done", "Dope", "Great Job", "Keep it up", "Sweet", "Awesome", "Superhot"};

    void Start()
    {
        Cursor.visible = false;

        datapass = GameObject.FindGameObjectWithTag("persistent").GetComponent<SceneData>();
        datapass.fromGame = true;
        datapass.score = 0;
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        difficulty = DifficultyCurve(timeSinceStart);
        Debug.Log(difficulty);
        countdown -= Time.deltaTime * difficulty;
        if (bulletsSpawned)
        {
            if(countdown < -2 + countdownNumber && !isDead)
            {
                if (countdownNumber > -3)
                {
                    countdownUI.ShowText((3 + countdownNumber).ToString(), 5);
                }
                else if(countdownNumber == -3)
                {
                    countdownUI.ShowText("Go", 5);
                }
                else
                {
                    bulletSpeed = SpeedCurve(bulletMoveTime) * 100;
                }
                countdownNumber--;
            }
            if(countdown < -10 && !isDead)
            {
                datapass.score++;
                countdownUI.ShowText(this.GetRewardText(), 5);
                DespawnBullets();
                bulletsSpawned = false;
                countdown = 3;
            }
            if(countdown < 0)
            {
                return;
            }
            bulletSpeed = SpeedCurve(countdown)*30;
        }
        else if(countdown<0 && !isDead)
        {
            countdownNumber = 0;
            bulletsSpawned = true;
            SpawnBullets(Mathf.FloorToInt(2+difficulty*2));
            countdown = bulletMoveTime;
            bulletSpeed = SpeedCurve(countdown) * 30;
        }
    }

    float DifficultyCurve(float t)
    {
        return Mathf.Log10(t + 3) / 1.2f + 1.5f;
    }

    float SpeedCurve(float t)
    {
        return Mathf.Exp((t - 1)) - 0.366f;
    }

    void DespawnBullets()
    {
        for(int i= bullets.Count-1; i>=0; i--)
        {
            Destroy(bullets[i].gameObject);
            bullets.RemoveAt(i);
        }
    }

    void SpawnBullets(int count)
    {
        Vector3 top = cam.ViewportToWorldPoint(new Vector3(1, 1, 10));
        Vector3 bottom = cam.ViewportToWorldPoint(new Vector3(0, 0, 10));

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

    string GetRewardText()
    {
        int i = Random.Range(0, RewardText.Length - 1);
        return this.RewardText[i];
    }
}
