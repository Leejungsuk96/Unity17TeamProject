using System;
using System.IO;
using UnityEngine;
public class VictoryDefeatCondition : MonoBehaviour
{
    //public int EnemyCountLimit = 20;
    //private int CurrentEnemyCount = 0;
    //private bool GameEnded = false;
    private string SaveFile;
    private GameObject EndingWindow;


    private void Awake()
    {
        SaveFile = Path.Combine(Application.persistentDataPath, "GameSave.json");
        LoadGame();
        EndingWindow = GameObject.FindWithTag("EndingWindow");
        if (EndingWindow != null)
        {
            EndingWindow.SetActive(false);
        }
    }
    private void Start()
    {
        GameManager.instance.OnGameOver += GameEnd;
        LoadGame();
    }
    //public void EnemySpawned()
    //{
    //    if (!GameEnded)
    //    {
    //        CurrentEnemyCount++;
    //        if (CurrentEnemyCount > GameoverEnemyCount)
    //        {
    //            GameEnd();
    //        }
    //    }
    //}

    private void SaveGame()
    {
        GameData gameData = new GameData
        {
            //savedPlayerGold = PlayerGoldManager.instance.GetPlayerGold()
        };
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(SaveFile, jsonString);
    }
    private void LoadGame()
    {
        if (File.Exists(SaveFile))
        {
            string jsonString = File.ReadAllText(SaveFile);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonString);

            //PlayerGoldManager.instance.SetPlayerGold(gameData.savedPlayerGold);
        }
    }

    private void GameEnd()
    {
        SaveGame();
        //GameEnded = true;
        ShowEndingWindow();
        Time.timeScale = 0f;
    }

    private void ShowEndingWindow()
    {
        if (EndingWindow != null)
        {
            EndingWindow.SetActive(true);
        }
    }
    [Serializable]
    private class GameData
    {
        public int savedPlayerGold;
    }
}