using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class mainSceneChange : MonoBehaviour {
    public Image select;
    public Image setting;
    public Image story;
    public Button selectBT;
    public Button settingBT;
    public Button storyBT;
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
    public void selectChange()
    {
        selectBT.image = select;
    }
    public void settingChange()
    {
        settingBT.image = setting;
    }
    public void storyChange()
    {
        storyBT.image = story;
    }
}
