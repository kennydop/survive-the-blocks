using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    
    public Text textEnergy;
    public Text textTimer;
    public int maxEnergy = 20;
    public int totalEnergy = 20;
    private DateTime nextEnergyTiime;
    private DateTime lastAddedTime;
    public int restoreDuration = 20;
    private bool restoring;
    public GameObject OutOfLives;
    private int ThemeState;


    void Start()
    {
        OutOfLives.SetActive(false);                                        
        Load();
        StartCoroutine(RestartRoutine());
        UpdateEnergy();
        ThemeState = PlayerPrefs.GetInt("themeState");

        if (ThemeState == 0)
        {
            textEnergy.color = Color.black;
        }

        if (ThemeState == 1)
        {
            textEnergy.color = Color.black;
        }

        if (ThemeState == 2)
        {
            textEnergy.color = Color.white;

        }
        if (ThemeState == 3)
        {
            textEnergy.color = Color.white;
        }

    }

    private IEnumerator RestartRoutine()
    {
        UpdateTimer();
        UpdateEnergy();
        restoring = true;

        while (totalEnergy < maxEnergy)
        {
            DateTime currentTime = DateTime.Now;
            DateTime counter = nextEnergyTiime;
            bool isAdding = false;

            while (currentTime > counter)
            {
                if (totalEnergy < maxEnergy)
                {
                    isAdding = true;
                    totalEnergy++;
                    DateTime timeToAdd = lastAddedTime > counter ? lastAddedTime : counter;
                    counter = AddDuraton(timeToAdd, restoreDuration);
                }
                else
                    break;
            }

            if (totalEnergy < 0)
            {
                totalEnergy = 0;
            }

            if (isAdding)
            {
                lastAddedTime = DateTime.Now;
                nextEnergyTiime = counter;
            }

            UpdateTimer();
            UpdateEnergy();
            Save();

            yield return null;
        }

        if(totalEnergy == maxEnergy)
        {
            textEnergy.text = "FULL!";
        }

        restoring = false;

    }

    private DateTime AddDuraton(DateTime time, int duration)
    {
        return time.AddMinutes(duration);
    }

    private void UpdateTimer()
    {
        if (totalEnergy >= maxEnergy)
        {
            textTimer.text = "";
            return;
        }

        TimeSpan t = nextEnergyTiime - DateTime.Now;
        String value = String.Format("{0}:{1:D2}:{2:D2}" ,(int) t.TotalHours, t.Minutes, t.Seconds);
        textTimer.text = value;
    }

    private void UpdateEnergy()
    {
        textEnergy.text = totalEnergy.ToString();
    }

    void Load()
    {
        totalEnergy = PlayerPrefs.GetInt("totalEnergy");
        nextEnergyTiime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastAddedTime = StringToDate(PlayerPrefs.GetString("lastAddedTime"));
    }

    void Save()
    {
        PlayerPrefs.SetInt("totalEnergy", totalEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTiime.ToString());
        PlayerPrefs.SetString("lastAddedTime", lastAddedTime.ToString());
    }

    private DateTime StringToDate(string date)
    {
        if (string.IsNullOrEmpty(date))
            return DateTime.Now;
       
        return DateTime.Parse(date);
    }


    public void UseEnergy()
    {
        totalEnergy--;
        UpdateEnergy();        

        if (!restoring)
        {
            if(totalEnergy +1 == maxEnergy) 
            { 
            nextEnergyTiime = AddDuraton(DateTime.Now, restoreDuration);
            }

            StartCoroutine(RestartRoutine());
        }


    }

    public void Back()
    {
        OutOfLives.SetActive(false);
    }

    public void Play()
    {
        if (totalEnergy <= 0)
        {
            OutOfLives.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }
    }
}
