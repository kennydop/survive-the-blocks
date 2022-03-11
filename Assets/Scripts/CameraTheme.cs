using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTheme : MonoBehaviour
{
    private int cameraTheme;
    Camera cam;
    public Color WhittishAsh, YellowishWhite;
    public Color Blue;
    public Color Dark;

    private void Start()
    {
        cameraTheme = PlayerPrefs.GetInt("themeState");
        cam = GetComponent<Camera>();

        if (cameraTheme == 0)
        {
            cam.backgroundColor = WhittishAsh;
        }

        if (cameraTheme == 1)
        {
            cam.backgroundColor = YellowishWhite;
        }

        if (cameraTheme == 2)
        {
            cam.backgroundColor = Blue;
        }

        if (cameraTheme == 3)
        {
            cam.backgroundColor = Dark;
        }

    }

    void Update()
    {
      

    }
}
