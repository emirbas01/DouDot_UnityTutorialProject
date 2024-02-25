using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizationTip : MonoBehaviour
{
    [SerializeField] Transform corner1, corner2;

    [SerializeField] GameObject coinPrefab;

    public int totalCoinCount;
    [SerializeField] int maxCoinCount;
    void Update()
    {
        if(totalCoinCount < maxCoinCount)
        {
            SelectRandomPoint();
        }
    }
    void SelectRandomPoint()
    {
        float x = Random.Range(corner1.position.x, corner2.position.x);
        float z = Random.Range(corner2.position.z, corner1.position.z);

        Vector3 spawnPosition = new Vector3(x, GameObject.Find("PLAYER").transform.position.y, z);
        CreateCoins(spawnPosition);
    }
    void CreateCoins(Vector3 spawnPosition)
    {
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        totalCoinCount++;
    }
}
