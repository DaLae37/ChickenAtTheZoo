using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutoClear : MonoBehaviour {
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Escape")
        {
            if (!PlayerPrefs.HasKey("tutorial3") || PlayerPrefs.GetInt("tutorial3") == 0)
                PlayerPrefs.SetInt("tutorial3", 1);
            SceneManager.LoadScene("stage1");
        }
    }
}
