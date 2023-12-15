using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDefeatCondition : MonoBehaviour
{
    public int EnemyKillGoal = 100;
    public int EnemyCountLimit = 20;

    private int CurrentEnemyKills = 0;
    private int CurrentEnemyCount = 0;

    private bool GameEnded = false;


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

    private void GameEnd()
    {
        GameEnded = true;
    }

}
