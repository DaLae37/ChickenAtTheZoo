using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSceneChange : MonoBehaviour
{
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void stage1()
    {
        SceneManager.LoadScene("stage1");
    }
}
