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

    public bool BuildTower() => HasEnoughGold(1) ? (gold -= 1) == 0 : false;//1��忡 Ÿ���� �������ְ� ���ִ� ��ɾ�
    public void GainGold(int amount) => Debug.Log($"{amount}��带 ȹ���߽��ϴ�. ���� ���: {gold += amount}");
    private bool HasEnoughGold(int amount) => gold >= amount;//��带 ����� ������ �ִ���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
