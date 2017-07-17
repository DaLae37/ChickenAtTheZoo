using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	void Awake(){

	}

	void Start(){
        GlobalAudioManager.instance.StartSound();
    }


	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Escape") {
			GlobalAudioManager.instance.PotalSound ();
		}
		else if (collision.collider.tag == "Lion") {
			SceneManager.LoadScene ("gameOverScene");
		}
        else if (collision.collider.tag == "Player"||collision.collider.tag == "Stone"||collision.collider.tag == "Ground") {
			GlobalAudioManager.instance.GroundSound ();
            if (this.ToString().Equals("player1 (Player)"))
            {
                PlayerControl.instance.isJumping[0] = false;
                PlayerControl.instance.isDashing[0] = false;
            }
            else if (this.ToString().Equals("player2 (Player)"))
            {
                PlayerControl.instance.isJumping[1] = false;
                PlayerControl.instance.isDashing[1] = false;
            }
            else if (this.ToString().Equals("player3 (Player)"))
            {
                PlayerControl.instance.isJumping[2] = false;
                PlayerControl.instance.isDashing[2] = false;
				PlayerControl.instance.doubleJum = false;
            }
			PlayerControl.instance.rb.velocity = new Vector3 (0, 0, 0);
        }
        else if(collision.collider.tag == "water")
        {
            SceneManager.LoadScene("gameOverScene");
        }
    }
}
