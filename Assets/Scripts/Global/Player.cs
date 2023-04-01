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

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Water")
		{
			SceneManager.LoadScene("gameOverScene");
		}
	}
	public void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Escape")
        {
            GlobalAudioManager.instance.PotalSound();
            if (this.ToString().Equals("player1 (Player)"))
            {
                PlayerControl.instance.playerchk[0] = true;
                if (!PlayerControl.instance.playerchk[1])
                    PlayerControl.instance.ctrPlayerIndex = 1;
                else if (!PlayerControl.instance.playerchk[2])
                    PlayerControl.instance.ctrPlayerIndex = 2;
                Destroy(PlayerControl.instance.playerList[0]);
            }
            else if (this.ToString().Equals("player2 (Player)"))
            {
                PlayerControl.instance.playerchk[1] = true;
                if (!PlayerControl.instance.playerchk[2])
                    PlayerControl.instance.ctrPlayerIndex = 2;
                else if (!PlayerControl.instance.playerchk[0])
                    PlayerControl.instance.ctrPlayerIndex = 0;
                Destroy(PlayerControl.instance.playerList[1]);
            }
            else if (this.ToString().Equals("player3 (Player)"))
            {
                PlayerControl.instance.playerchk[2] = true;
                if (!PlayerControl.instance.playerchk[0])
                    PlayerControl.instance.ctrPlayerIndex = 0;
                else if (!PlayerControl.instance.playerchk[1])
                    PlayerControl.instance.ctrPlayerIndex = 1;
                Destroy(PlayerControl.instance.playerList[2]);
            }
            Destroy(collision.gameObject);
            PlayerControl.instance.rb = PlayerControl.instance.playerList[PlayerControl.instance.ctrPlayerIndex].GetComponent<Rigidbody2D>();
            if (PlayerControl.instance.playerchk[0] && PlayerControl.instance.playerchk[1] && PlayerControl.instance.playerchk[2])
            {
                SceneManager.LoadScene("clearScene");
            }
        }
        else if (collision.collider.tag == "Lion")
        {
            SceneManager.LoadScene("gameOverScene");
        }
        else if (collision.collider.tag == "Player" || collision.collider.tag == "Stone" || collision.collider.tag == "Ground")
        {
            int index = 0;
            GlobalAudioManager.instance.GroundSound();
            if (this.ToString().Equals("player1 (Player)"))
            {
                PlayerControl.instance.isJumping[0] = false;
                PlayerControl.instance.isDashing[0] = false;
            }
            else if (this.ToString().Equals("player2 (Player)"))
            {
                index = 1;
                PlayerControl.instance.isJumping[1] = false;
                PlayerControl.instance.isDashing[1] = false;
            }
            else if (this.ToString().Equals("player3 (Player)"))
            {
                index = 2;
                PlayerControl.instance.isJumping[2] = false;
                PlayerControl.instance.isDashing[2] = false;
                PlayerControl.instance.doubleJum = false;
            }
            PlayerControl.instance.playerList[index].GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
	public void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.collider.tag == "Crocodile") {
			SceneManager.LoadScene ("gameOverScene");
		}
	}
}
