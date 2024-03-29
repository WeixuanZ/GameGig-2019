﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetScores : MonoBehaviour
{
    public GameObject names;
    public GameObject scores;
    public TypeText input;

    SceneData sceneData;
    List<PlayerData> playerScores;
    int scoreIndex = -1;
    void Start()
    {
        sceneData = GameObject.FindGameObjectWithTag("persistent").GetComponent<SceneData>();
        playerScores = GetAllPlayerData();

        FlashText[] namesFlash = names.GetComponentsInChildren<FlashText>();
        FlashText[] scoresFlash = scores.GetComponentsInChildren<FlashText>();

        for (int i = 0; i < 5; i++)
        {
            if(!sceneData.fromGame) break;
            if (playerScores[i].score <= sceneData.score)
            {
                namesFlash[i].enabled = true;
                scoresFlash[i].enabled = true;
                scoreIndex = i;
                playerScores.Insert(i, new PlayerData("???", sceneData.score));
                break;
            }
        }
        UpdateScoreboard();
    }

    // Update is called once per frame

    public void UpdateScoreboard()
    {
        TextMeshProUGUI[] namesText = names.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] scoresText = scores.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i=0; i<5; i++)
        {
            if(i==scoreIndex)
            {
                playerScores[i].name = input.currentString;
                if (input.currentString.Length == 0)
                {
                    playerScores[i].name = "???";
                }
            }
            namesText[i].text = playerScores[i].name;
            scoresText[i].text = playerScores[i].score.ToString();
        }
        SavePlayerData(playerScores);
    }

    void SavePlayerData(List<PlayerData> playerScores)
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("Score_" + i.ToString(), playerScores[i].score);
            PlayerPrefs.SetString("Name_" + i.ToString(), playerScores[i].name);
        }
    }

    List<PlayerData> GetAllPlayerData()
    {
        List<PlayerData> playerScores = new List<PlayerData>();
        for(int i=0; i<5; i++) {
            int score = 0;
            string name = "???";
            if (PlayerPrefs.HasKey("Score_" + i.ToString()))
            {
                score = PlayerPrefs.GetInt("Score_" + i.ToString());
                name = PlayerPrefs.GetString("Name_" + i.ToString());
            }
            playerScores.Add(new PlayerData(name, score));
        }
        return playerScores;
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