using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class countdown : MonoBehaviour
{
    int CountNo = 3;
    public Text CountdownText;
    public GameObject Countdown;
    private int ThemeState;
    public Color dark;

    void Start()
    {
        StartCoroutine(CountdownToStart());
        ThemeState = PlayerPrefs.GetInt("themeState");

        if (ThemeState == 0)
        {
            CountdownText.color = dark;
        }

        if (ThemeState == 1)
        {
            CountdownText.color = dark;
        }

        if (ThemeState == 2)
        {
            CountdownText.color = Color.white;

        }
        if (ThemeState == 3)
        {
            CountdownText.color = Color.white;
        }

    }

    private void Update()
    {
            
    }

    IEnumerator CountdownToStart()
    {
        while (CountNo > 0)
        {
            CountdownText.text = CountNo.ToString();
            yield return new WaitForSeconds(1f);
            CountNo--;
        }

        CountdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        Countdown.SetActive(false);
    } 
}
