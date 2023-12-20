using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoldManager : MonoBehaviour
{
    private int playerGold = 0;

    public static PlayerGoldManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddGold(int amount)
    {
        playerGold += amount;
        Debug.Log($"gold{playerGold}");
    }
}
