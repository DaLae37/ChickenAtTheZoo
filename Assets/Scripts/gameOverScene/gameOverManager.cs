using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverManager : MonoBehaviour {
    public void reStart()
    {
        SceneManager.LoadScene("loadingScene");
    }
    public void select()
    {
        SceneManager.LoadScene("stageSelectScene");
    }
}
