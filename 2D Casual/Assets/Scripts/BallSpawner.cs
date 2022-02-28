using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballprefab;

    void Start()
    {
        
    }

    public void Spawn() {
        Instantiate(ballprefab, new Vector3(0, -2, 0), Quaternion.identity);
    }

}
