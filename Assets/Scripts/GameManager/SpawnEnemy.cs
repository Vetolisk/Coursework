using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> lootPrefabs = new List<GameObject>();
    public int amountEnemies = 5;

    private void Start()
    {
        SpawnEl();
    }

    public void SpawnEl()
    {
        for (int i = 0; i < amountEnemies; i++)
        {
            int randomNumber = Random.Range(0, spawnPoints.Count);
            GameObject loot = SpawnLoot(spawnPoints[randomNumber]);
            spawnPoints.RemoveAt(randomNumber);
        }
    }
    private GameObject SpawnLoot(Transform spawnPoint)
    {
        var prefab = lootPrefabs[Random.Range(0, lootPrefabs.Count)];
        return Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
