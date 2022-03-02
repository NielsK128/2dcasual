using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHighscore : MonoBehaviour
{
        public TMP_Text highscoreText;
    void Start()
    {
    highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
    }

}
