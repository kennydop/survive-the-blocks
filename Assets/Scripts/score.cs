using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text ScoreText;
    public Text endScoreText;
    public Text highScoreText;
    public float Score = 0.0f;
    private int ThemeState;


    void Start()
    {
        highScoreText.text = PlayerPrefs.GetFloat("hiscore").ToString("0");
        ThemeState = PlayerPrefs.GetInt("themeState");

        if (ThemeState == 0)
        {
            ScoreText.color = Color.black;
        }

        if (ThemeState == 1)
        {
            ScoreText.color = Color.black;
        }

        if (ThemeState == 2)
        {
            ScoreText.color = Color.white;

        }
        if (ThemeState == 3)
        {
            ScoreText.color = Color.white;
        }
    } 
       


    void Update()
    {
        StartCoroutine(Scoring());

        if (PlayerPrefs.GetFloat("hiscore") <= Score)
        {
            PlayerPrefs.SetFloat("hiscore", Score);
            highScoreText.text = PlayerPrefs.GetFloat("hiscore").ToString("0");
        }
        
    }

    IEnumerator Scoring()
    {
        yield return new WaitForSeconds(4);
        Score += Time.deltaTime * 5;
        ScoreText.text = ((int)Score).ToString("0");
        endScoreText.text = ((int)Score).ToString("0");

    }

}
