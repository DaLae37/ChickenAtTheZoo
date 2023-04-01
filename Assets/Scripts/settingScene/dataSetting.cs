using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dataSetting : MonoBehaviour {
    public GameObject obj;
    public void onClick()
    {
        if (obj.active == true)
            Hide();
        else
            unHide();
    }
    public void onReset()
    {
        PlayerPrefs.SetInt("new", 1);
        SceneManager.LoadScene("mainScene");
    }
    public void Hide()
    {
        obj.active = false;
    }
    public void unHide()
    {
        obj.active = true;
    }
}
