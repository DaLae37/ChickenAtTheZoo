using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class storySceneManger : MonoBehaviour {
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
}
