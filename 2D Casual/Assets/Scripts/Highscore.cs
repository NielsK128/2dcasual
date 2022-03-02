using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    private int score;
    public TMP_Text highscoreTextPause;
    public TMP_Text highscoreTextGameOver;

    void Start()
    {

    }

    void Update()
    {
        score = this.gameObject.GetComponent<Score>().score;
        if(score > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", score);
        }
        highscoreTextPause.text = PlayerPrefs.GetInt("highscore").ToString();
        highscoreTextGameOver.text = PlayerPrefs.GetInt("highscore").ToString();
    }
}
