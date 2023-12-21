using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGoldManager : MonoBehaviour
{
    public int playerGold = 0;
    public TextMeshProUGUI gold;

    public static PlayerGoldManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerGold += 40;
    }

    private void Update()
    {
        gold.text = playerGold.ToString();
    }

    public void AddGold(int amount)
    {
        playerGold += amount;
        Debug.Log($"gold{playerGold}");
    }
}
