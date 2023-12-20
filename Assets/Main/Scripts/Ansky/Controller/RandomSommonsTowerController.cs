using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSommonsTowerController : MonoBehaviour
{
    private int currentSommonsCount = 0;

    public List<GameObject> summonsTowersPrefabs = new List<GameObject>();

    [SerializeField] private Transform summonsPositionRoot;
    public List<Transform> summonsTowersPositions = new List<Transform>();

    [SerializeField] private Button summonButton;

    private void Awake()
    {
        for(int i = 0; i < summonsPositionRoot.childCount; i++)
        {
            summonsTowersPositions.Add(summonsPositionRoot.GetChild(i));
        }
    }

    private void Start()
    {
        summonButton.onClick.AddListener(SummonsRandomTower);
    }

    public void SummonsRandomTower()
    {
        Debug.Log("aaa");
        int randomTowerIndex = Random.Range(0, summonsTowersPrefabs.Count);
        GameObject summonsTower = Instantiate(summonsTowersPrefabs[randomTowerIndex], summonsTowersPositions[0].position, Quaternion.identity);
        summonsTower.transform.parent = transform;
        currentSommonsCount++;
    }
}
