using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject ingameUI;
    public void endGame() {
        gameOverPanel.SetActive(true);
        ingameUI.SetActive(false);
        Time.timeScale = 0;
        this.gameObject.GetComponent<MuteManager>().changeButtons();

    }



}
