using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    public Toggle TiltControls;
    public Toggle dragControls;
    private int toggle_state;


    private void Start()
    {
        toggle_state = PlayerPrefs.GetInt("toggleState");

        if(toggle_state == 1)
        {
            TiltControls.isOn = true;
            dragControls.isOn = false;
        }

        else if (toggle_state == 2)
        {
            TiltControls.isOn = false;
            dragControls.isOn = true;
        }
    }

    void Update()
    {
        if (TiltControls.isOn)
        {
            toggle_state = 1;
            PlayerPrefs.SetInt("toggleState", toggle_state);
        }

        if(dragControls.isOn)
        {
            toggle_state = 2;
            PlayerPrefs.SetInt("toggleState", toggle_state);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

 
}
