using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class settingSceneCtr : MonoBehaviour {
    public void mainScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene("mainScene");
            }
        }
    }
}
