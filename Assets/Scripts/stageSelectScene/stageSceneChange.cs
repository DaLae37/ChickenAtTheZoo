using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSceneChange : MonoBehaviour
{
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                mainScene();
            }
        }
    }
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void tutorial1()
    {
        PlayerPrefs.SetString("load", "tutorial1");
        SceneManager.LoadScene("loadingScene");
    }
    public void tutorial2()
    {
        PlayerPrefs.SetString("load", "tutorial2");
        SceneManager.LoadScene("loadingScene"); ;
    }
    public void tutorial3()
    {
        PlayerPrefs.SetString("load", "tutorial3");
        SceneManager.LoadScene("loadingScene");
    }
    public void stage1()
    {
        PlayerPrefs.SetString("load", "stage1");
        SceneManager.LoadScene("loadingScene");
    }
    public void stage2()
    {
        PlayerPrefs.SetString("load", "stage2");
        SceneManager.LoadScene("loadingScene");
    }
    public void stage3()
    {
        PlayerPrefs.SetString("load", "stage3");
        SceneManager.LoadScene("loadingScene");
    }
    public void stage4()
    {
        PlayerPrefs.SetString("load", "stage4");
        SceneManager.LoadScene("loadingScene");
    }
}
