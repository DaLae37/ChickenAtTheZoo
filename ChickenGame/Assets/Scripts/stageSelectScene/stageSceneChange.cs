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
        SceneManager.LoadScene("tutorial1");
    }
    public void tutorial2()
    {
        SceneManager.LoadScene("tutorial2");
    }
    public void tutorial3()
    {
        SceneManager.LoadScene("tutorial3");
    }
    public void stage1()
    {
        SceneManager.LoadScene("stage1");
    }
    public void stage2()
    {
        SceneManager.LoadScene("stage2");
    }
    public void stage3()
    {
        SceneManager.LoadScene("stage3");
    }
    public void stage4()
    {
        SceneManager.LoadScene("stage4");
    }
}
