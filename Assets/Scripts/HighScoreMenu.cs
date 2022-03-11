using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text highscore;

    void Start()
    {
        highscore.text = PlayerPrefs.GetFloat("hiscore").ToString("0");
    }

}
