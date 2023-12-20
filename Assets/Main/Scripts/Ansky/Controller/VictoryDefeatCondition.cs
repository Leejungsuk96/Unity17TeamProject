using System;
using System.IO;
using UnityEngine;
public class VictoryDefeatCondition : MonoBehaviour
{
    public int EnemyKillGoal = 100;
    public int EnemyCountLimit = 20;
    private int CurrentEnemyKills = 0;
    private int CurrentEnemyCount = 0;
    private bool GameEnded = false;
    private string SaveFile;
    private void Start()
    {
        SaveFile = Path.Combine(Application.persistentDataPath, "GameSave.json");
        LoadGame();
    }
    public void EnemyKilled()
    {
        if (!GameEnded)
        {
            CurrentEnemyKills++;
            if (CurrentEnemyKills >= EnemyKillGoal)
            {
                GameEnd();
            }
        }
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
            //게임 데이터 적용
        }
    }
    private void GameEnd()
    {
        GameEnded = true;
    }
    [System.Serializable]
    private class GameData
    {
        //저장할 데이터 추가(플레이어체력,위치,점수 등)
    }
}
