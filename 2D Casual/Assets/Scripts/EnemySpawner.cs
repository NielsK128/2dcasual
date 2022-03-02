using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemy());    }

    IEnumerator SpawnEnemy() {
    yield return new WaitForSeconds(2f);
    Instantiate(enemyPrefab, new Vector3(Random.Range((float)-2.5, (float)2.5), 6, 0), Quaternion.identity);
    StartCoroutine(SpawnEnemy());
    }
}
