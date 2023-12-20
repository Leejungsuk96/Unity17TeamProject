using System;
using System.IO;
using UnityEngine;

public class VictoryDefeatCondition : MonoBehaviour
{
    private int CurrentEnemyCount = 0;
    private bool GameEnded = false;
    private string SaveFile;
    private GameObject EndingWindow;

    private void Start()
    {
        SaveFile = Path.Combine(Application.persistentDataPath, "GameSave.json");
        LoadGame();

        EndingWindow = GameObject.Find("Canvas/EndingWindow");
        if (EndingWindow != null)
        {
            EndingWindow.SetActive(false);
        }
    }

    public void EnemySpawned(GameObject enemyInstance)
    {
        Debug.Log("Enemy Spawned: " + enemyInstance.tag);

        if (!GameEnded && enemyInstance.CompareTag("Enemy"))
        {
            int enemyWeight = GetEnemyWeight(enemyInstance);
            CurrentEnemyCount += enemyWeight;

            if (CurrentEnemyCount >= 10)
            {
                GameEnd();
            }
        }
    }

    private int GetEnemyWeight(GameObject enemyInstance)
    {
        if (enemyInstance.CompareTag("EnemyA"))
        {
            return 1;
        }
        else if (enemyInstance.CompareTag("EnemyB"))
        {
            return 2;
        }
        else if (enemyInstance.CompareTag("EnemyC"))
        {
            return 3;
        }
        return 0;
    }

    private void GameEnd()
    {
        GameEnded = true;
        ShowEndingWindow();
        SaveGame();
    }

    private void ShowEndingWindow()
    {
        if (EndingWindow != null)
        {
            EndingWindow.SetActive(true);
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

    [Serializable]
    private class GameData
    {
        //저장할 데이터 추가(플레이어체력,위치,점수 등)
    }
}
