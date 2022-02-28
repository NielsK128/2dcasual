using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    void Update() {
        scoreText.text = "Score: " + score; 
    }

    public void increaseScore(int scoreIncrease) {
        score += scoreIncrease;
    }
}
