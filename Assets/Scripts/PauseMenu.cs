using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public GameObject PausePanel;
    public Text ScoreText;
    public GameObject PauseButton;
    public GameObject PauseButton1;
    int lives;
    public Text Lives;
    int ThemeState;
    public Color dark;

	
    void Start()
    {
        ThemeState = PlayerPrefs.GetInt("themeState");
        PausePanel.SetActive(false);

    }




	public void Pause ()   
    {
        PauseButton.SetActive(false);
        PauseButton1.SetActive(false);
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
	

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
       
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        lives--;
        Lives.text = lives.ToString();
        SceneManager.LoadScene("Game");
        
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnApplicationPause(bool pause)
    {
        Pause();

    }
}
