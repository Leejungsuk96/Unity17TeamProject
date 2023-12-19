using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reward : MonoBehaviour
{
    public string type = "Gold";

    public int GetRandomAmount(int min, int max)
    { 
        return UnityEngine.Random.Range(min, max +1);
    }

    private int gold;

    public bool BuildTower() => HasEnoughGold(1) ? (gold -= 1) == 0 : false;//1골드에 타워를 지을수있게 해주는 명령어
    public void GainGold(int amount) => Debug.Log($"{amount}골드를 획득했습니다. 현재 골드: {gold += amount}");
    private bool HasEnoughGold(int amount) => gold >= amount;//골드를 충분히 가지고 있는지

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
