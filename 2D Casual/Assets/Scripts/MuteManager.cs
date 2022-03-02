using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    public bool isMuted;

    public Sprite enableSound;
    public Sprite disableSound;

    public void Start() {
        isMuted = intToBool(PlayerPrefs.GetInt("muted"));
        changeButtons();
        if(isMuted == true) {
            AudioListener.pause = true;
        }
    }
    public void MutePressed() {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("muted", boolToInt(isMuted));
        AudioListener.pause = isMuted;
        if(isMuted == false) {
            GameObject.FindWithTag("SoundToggle").GetComponent<Image>().sprite = disableSound;
        } else {
            GameObject.FindWithTag("SoundToggle").GetComponent<Image>().sprite = enableSound;
        }
    }

    public void changeButtons() {
                if(isMuted == false) {
            this.gameObject.GetComponent<Image>().sprite = disableSound;
        } else {
            this.gameObject.GetComponent<Image>().sprite = enableSound;
        }
    }

    public bool getIsMuted() {
        return isMuted;
    }
    int boolToInt(bool val)
{
    if (val)
        return 1;
    else
        return 0;
}
bool intToBool(int val)
{
    if (val != 0)
        return true;
    else
        return false;
}

}
