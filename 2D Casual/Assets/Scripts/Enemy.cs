using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int killReward;
    public Vector2 movement;
    public Rigidbody2D rb;
    public GameObject explosionParticles;
    public GameObject explosionSound;
    public GameObject mechanics;
    void Start() {
        mechanics = GameObject.FindWithTag("Mechanics");
        if(mechanics.GetComponent<Score>().getScore() <= 250) {
        speed = speed - (float) (mechanics.GetComponent<Score>().getScore() * 0.01); } else
        {
        speed = (float) -2.5;
        }
    }
    
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = rb.position + movement * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag != "Floor") {
        GameObject.FindWithTag("Mechanics").GetComponent<Score>().increaseScore(killReward); }
        else {
        GameObject.FindWithTag("Mechanics").GetComponent<GameOver>().endGame(); }
        Instantiate(explosionParticles, this.gameObject.transform.position, Quaternion.identity );
        Instantiate(explosionSound, this.gameObject.transform.position, Quaternion.identity );
        Destroy(this.gameObject);
    }
}
