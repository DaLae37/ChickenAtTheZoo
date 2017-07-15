using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RounChicken : MonoBehaviour
{
    public Transform wb;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Wave")
        {
            PlayerControl.instance.isJumping[1] = false;
            PlayerControl.instance.isDashing[1] = false;
            PlayerControl.instance.rb.velocity = new Vector3(0, 0, 0);
            if(collision.collider.tag == "Wave")
            {
                transform.SetParent(wb);
                
            }
            
        }
        else if (collision.collider.tag == "Escape")
        {
            if(!PlayerPrefs.HasKey("tutorial2") || PlayerPrefs.GetInt("tutorial2") == 0)
                PlayerPrefs.SetInt("tutorial2", 1);
            SceneManager.LoadScene("tutorial3");
        }
    }
    public void Update()
    {
        if (PlayerControl.instance.isJumping[1])
        {
            transform.SetParent(null);
        }
    }
}
