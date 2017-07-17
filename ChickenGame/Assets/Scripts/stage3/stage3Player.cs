using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage3Player : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Escape") {
			GlobalAudioManager.instance.PotalSound ();
			SceneManager.LoadScene ("clearScene");
		}
		if (collision.collider.tag == "Lion") {
			SceneManager.LoadScene ("gameOverScene");
		}
		if (collision.collider.tag == "Player"||collision.collider.tag == "Stone"||collision.collider.tag == "Ground") {
			GlobalAudioManager.instance.GroundSound ();

			stage3PlayerControl.instance.isJumping = false;
			stage3PlayerControl.instance.isDashing = false;
			stage3PlayerControl.instance.rb.velocity = new Vector3 (0, 0, 0);
		}
	}
}
