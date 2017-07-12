using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainSceneChange : MonoBehaviour {
    public void stageSelectScene()
    {
        SceneManager.LoadScene("stageSelectScene");
    }
    public void settingScene()
    {
        SceneManager.LoadScene("settingScene");
    }
    public void storyScene()
    {
        SceneManager.LoadScene("storyScene");
    }
}
