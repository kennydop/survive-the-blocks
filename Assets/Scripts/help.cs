﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class help : MonoBehaviour
{
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }
}
