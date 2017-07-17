using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clearSceneManager : MonoBehaviour
{
    string nowScene;
    void Start()
    {
		GlobalAudioManager.instance.ClearSound ();
        nowScene = PlayerPrefs.GetString("load");
    }
    public void selectScene()
    {
        SceneManager.LoadScene("stageSelectScene");
    }
    public void story()
    {
        SceneManager.LoadScene(nowScene + "story");
    }
    public void nextScene()
    {
        Debug.Log(nowScene);
        if (nowScene.Equals("tutorial1"))
            PlayerPrefs.SetString("load", "tutorial2");
        else if (nowScene.Equals("tutorial2"))
            PlayerPrefs.SetString("load", "tutorial3");
        else if (nowScene.Equals("tutorial3"))
            PlayerPrefs.SetString("load", "stage1");
        else if (nowScene.Equals("stage1"))
            PlayerPrefs.SetString("load", "stage2");
        else if (nowScene.Equals("stage2"))
            PlayerPrefs.SetString("load", "stage3");
        else if (nowScene.Equals("stage3"))
            PlayerPrefs.SetString("load", "stage4");
        SceneManager.LoadScene("loadingScene");
    }
}
