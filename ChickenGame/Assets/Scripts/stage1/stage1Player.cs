using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage1Player : MonoBehaviour {
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Escape") {
			if (this.ToString().Equals("player1 (stage1Player)"))
			{
				Debug.Log ("Escape");
				stage1PlayerControl.instance.isClear[0] = true;
				Destroy (this.gameObject);
				Destroy (collision.gameObject);
				if (stage1PlayerControl.instance.isClear [1] == true) {
					SceneManager.LoadScene ("clearScene");
				} else {
					stage1PlayerControl.instance.ctrPlayerIndex = 1;
				}
			}
			if (this.ToString().Equals("player3 (stage1Player)"))
			{
				stage1PlayerControl.instance.isClear[1] = true;
				Destroy (this.gameObject);
				Destroy (collision.gameObject);
				if (stage1PlayerControl.instance.isClear [0] == true) {
					SceneManager.LoadScene ("clearScene");
				}else {
					stage1PlayerControl.instance.ctrPlayerIndex = 0;
				}
			}
		}

		if (collision.collider.tag == "Player"||collision.collider.tag == "Ground") {
			if (this.ToString().Equals("player1 (stage1Player)"))
			{
				stage1PlayerControl.instance.isJumping[0] = false;
			}
			else if (this.ToString().Equals("player3 (stage1Player)"))
			{
				stage1PlayerControl.instance.isJumping[1] = false;
				stage1PlayerControl.instance.doubleJum = false;
			}
			stage1PlayerControl.instance.rb.velocity = new Vector3 (0, 0, 0);
		}
	}
}
