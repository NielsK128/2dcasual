using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    void Start()
    {
        
    }

    public void SpawnBall() {
        Instantiate(ballPrefab, new Vector3(0, -2, 0), Quaternion.identity);
    }

}
