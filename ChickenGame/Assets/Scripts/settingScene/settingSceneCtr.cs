using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class settingSceneCtr : MonoBehaviour {
	public Slider Slider1;
	public Slider Slider2;
    public void mainScene()
    {
		PlayerPrefs.SetFloat("bgm",Slider1.value);
		PlayerPrefs.SetFloat("eft",Slider2.value);
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
