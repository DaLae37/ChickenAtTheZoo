using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class isClear : MonoBehaviour {
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Escape")
        {
            if (!PlayerPrefs.HasKey("tutorial1") || PlayerPrefs.GetInt("tutorial1") == 0)
                PlayerPrefs.SetInt("tutorial1", 1);
            SceneManager.LoadScene("tutorial2");
        }
    }
}
