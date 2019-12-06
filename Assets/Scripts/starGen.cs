using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starGen : MonoBehaviour
{
    public GameObject starPre;
    public Camera cam;
    private List<GameObject> stars;
    private List<float> starDist;
    // Start is called before the first frame update
    void Start()
    {
        stars = new List<GameObject>();
        starDist = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 top = cam.ViewportToWorldPoint(new Vector3(1, 1, 10));
        Vector3 bottom = cam.ViewportToWorldPoint(new Vector3(0, 0, 10));

        if(stars.Count < 1000)
        {
            float yRange = top.y - bottom.y;

            GameObject star = Instantiate(starPre, new Vector3(top.x, bottom.y + yRange * Random.value, 10), Quaternion.identity);
            float starDistF = Random.value;
            star.transform.localScale *= starDistF;
            stars.Add(star);
            starDist.Add(starDistF);
        }
        for(int i= stars.Count-1; i>=0; i--)
        {
            if(cam.WorldToViewportPoint(stars[i].transform.position).x < 0)
            {
                DestroyImmediate(stars[i]);
                stars.RemoveAt(i);
                starDist.RemoveAt(i);
            }
            stars[i].transform.position -= new Vector3(starDist[i] * starDist[i], 0, 0);
        }
    }
}
