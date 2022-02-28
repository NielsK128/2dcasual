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
    yield return new WaitForSeconds(3f);
    Instantiate(enemyPrefab, new Vector3(Random.Range(-2, 2), 6, 0), Quaternion.identity);
    StartCoroutine(SpawnEnemy());
    }
}
