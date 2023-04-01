﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class stage3Manager : MonoBehaviour {
    public GameObject obj;
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (obj.active == false)
                    unHide();
                else
                    Hide();
            }
        }
    }
    public void reStart()
    {
        Hide();
        SceneManager.LoadScene("loadingScene");
    }
    public void selectScene()
    {
        SceneManager.LoadScene("stageSelectScene");
    }
    public void Hide()
    {
        obj.active = false;
    }
    public void unHide()
    {
        obj.active = true;
    }
}
