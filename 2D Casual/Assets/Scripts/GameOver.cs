using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void endGame() {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
