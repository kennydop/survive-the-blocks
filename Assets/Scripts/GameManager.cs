using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public float slowness = 30f;
    public GameObject Player;
    public GameObject pausebtn, pausebtn1;
    private int toggle_state;

    private int ThemeState;
    public GameObject PlayerDefaualt, PlayerLight, PlayerPrimary, PlayerDark;
    public GameObject ObstacleDefault, ObstacleLight, ObstaclePrimary, ObstacleDark;

    private void Start()
    {
        toggle_state = PlayerPrefs.GetInt("toggleState");
        ThemeState = PlayerPrefs.GetInt("themeState");
        
        PlayerDefaualt.SetActive(false);
        PlayerLight.SetActive(false);
        PlayerPrimary.SetActive(false);
        PlayerDark.SetActive(false);

        ObstacleDefault.SetActive(false);
        ObstacleLight.SetActive(false);
        ObstaclePrimary.SetActive(false);
        ObstacleDark.SetActive(false);

        


        if (toggle_state == 1)
        {
            
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<dragMovements>().enabled = false;

        }

        else if (toggle_state == 2)
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<dragMovements>().enabled = true;
        }



        if (ThemeState == 0)
        {
            PlayerDefaualt.SetActive(true);
            PlayerLight.SetActive(false);
            PlayerPrimary.SetActive(false);
            PlayerDark.SetActive(false);

            ObstacleDefault.SetActive(true);
            ObstacleLight.SetActive(false);
            ObstaclePrimary.SetActive(false);
            ObstacleDark.SetActive(false);

            pausebtn.SetActive(true);
            pausebtn1.SetActive(false);

        }

        if (ThemeState == 1)
        {
            PlayerDefaualt.SetActive(false);
            PlayerLight.SetActive(true);
            PlayerPrimary.SetActive(false);
            PlayerDark.SetActive(false);

            ObstacleDefault.SetActive(false);
            ObstacleLight.SetActive(true);
            ObstaclePrimary.SetActive(false);
            ObstacleDark.SetActive(false);

            pausebtn.SetActive(true);
            pausebtn1.SetActive(false);
        }

        if (ThemeState == 2)
        {
            PlayerDefaualt.SetActive(false);
            PlayerLight.SetActive(false);
            PlayerPrimary.SetActive(true);
            PlayerDark.SetActive(false);

            ObstacleDefault.SetActive(false);
            ObstacleLight.SetActive(false);
            ObstaclePrimary.SetActive(true);
            ObstacleDark.SetActive(false);

            pausebtn.SetActive(false);
            pausebtn1.SetActive(true);
        }

        if (ThemeState == 3)
        {
            PlayerDefaualt.SetActive(false);
            PlayerLight.SetActive(false);
            PlayerPrimary.SetActive(false);
            PlayerDark.SetActive(true);

            ObstacleDefault.SetActive(false);
            ObstacleLight.SetActive(false);
            ObstaclePrimary.SetActive(false);
            ObstacleDark.SetActive(true);

            pausebtn.SetActive(false);
            pausebtn1.SetActive(true);
        }

    }

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
        
    }

    IEnumerator RestartLevel()
    {
        
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        
        yield return new WaitForSeconds(1f / slowness);

        Time.timeScale = 0;

    }

 
}
