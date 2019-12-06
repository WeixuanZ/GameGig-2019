using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getScores : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SavePlayerData(List<PlayerData> playerScores)
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("Score_" + i.ToString(), playerScores[i].score);
            PlayerPrefs.SetString("Name_" + i.ToString(), playerScores[i].name);
        }
    }

    void GetAllPlayerData()
    {
        List<PlayerData> playerScores = new List<PlayerData>();
        for(int i=0; i<5; i++) {
            int score = 0;
            string name = "UNKNOWN PLAYER";
            if (PlayerPrefs.HasKey("Score_" + i.ToString()))
            {
                score = PlayerPrefs.GetInt("Score_" + i.ToString());
                name = PlayerPrefs.GetString("Name_" + i.ToString());
            }
            playerScores.Add(new PlayerData(name, score));
        }
    }
}


class PlayerData
{
    public int score;
    public string name;

    public PlayerData(string name, int score)
    {
        this.score = score;
        this.name = name;
    }
}