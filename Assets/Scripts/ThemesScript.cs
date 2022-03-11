using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemesScript : MonoBehaviour
{
    public Dropdown Themes;
    private int theme_State;
    void Start()
    {

        theme_State = PlayerPrefs.GetInt("themeState");

       if (theme_State == 0)
        {
            Themes.value = 0;
        }
        if (theme_State == 1)
        {
            Themes.value = 1;
        }
        if (theme_State == 2)
        {
            Themes.value = 2;
        }
        if (theme_State == 3)
        {
            Themes.value = 3;
        }
    }

    void Update()
    {
        if (Themes.value == 0)
        {
            theme_State = 0;
            PlayerPrefs.SetInt("themeState", theme_State);
        }

        if (Themes.value == 1)
        {
            theme_State = 1;
            PlayerPrefs.SetInt("themeState", theme_State);
        }

        if (Themes.value == 2)
        {
            theme_State = 2;
            PlayerPrefs.SetInt("themeState", theme_State);
        }

        if (Themes.value == 3)
        {
            theme_State = 3;
            PlayerPrefs.SetInt("themeState", theme_State);
        }

    }
}
