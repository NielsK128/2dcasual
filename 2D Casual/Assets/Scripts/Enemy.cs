using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int killReward;
    public Vector2 movement;
    public Rigidbody2D rb;
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = rb.position + movement * speed * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D col) {
        GameObject.FindWithTag("Mechanics").GetComponent<Score>().increaseScore(killReward);
        Destroy(this.gameObject);
    }
}
