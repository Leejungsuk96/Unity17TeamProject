using System;
using System.IO;
using UnityEngine;
using System.Collections;
using TMPro;

public class VictoryDefeatCondition : GameManager
{
    public int EnemyCountLimit = 20;
    private int CurrentEnemyCount = 0;
    private bool GameEnded = false;
    private string SaveFile;


    //protected override void EnemyCount()
    //{
    //    base.EnemyCount();

    //    if (enemyCount >= 20)
    //    {
    //        GameEnd(true);
    //    }
    //}

    //public override void GameEnd(bool victory)
    //{
    //    base.GameEnd(victory);

    //    if (victory)
    //    {
            
    //    }

    //}


    private void Start()
    {
        SaveFile = Path.Combine(Application.persistentDataPath, "GameSave.json");
        LoadGame();
    }

    public void EnemySpawned()
    {
        if (!GameEnded)
        {
            CurrentEnemyCount++;
            if (CurrentEnemyCount > EnemyCountLimit)
            {
                GameEnd();
            }
        }
    }

    private void SaveGame()
    {
        GameData gameData = new GameData(/* 저장 데이터 */);
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(SaveFile, jsonString);
    }

    private void LoadGame()
    {
        if (File.Exists(SaveFile))
        {
            string jsonString = File.ReadAllText(SaveFile);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonString);
            // 게임 데이터 적용
        }
    }

    //public override void GameEnd()
    //{
    //    base.GameEnd();
    //    SaveGame();
    //}


    [Serializable]
    private class GameData
    {
        // 추가적인 저장할 데이터가 있다면 여기에 추가
    }
}
