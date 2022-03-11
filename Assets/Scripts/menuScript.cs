using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Text textEnergy;
    public Color dark;
    private void Start()
    {
        textEnergy.color = dark;
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
     
    }
    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Quit()
    {
        Application.Quit();
    }

   
}
