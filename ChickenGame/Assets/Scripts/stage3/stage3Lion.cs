using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3Lion : MonoBehaviour {

	public float speed = 0.3f; 
	public float range = 5f;
	public bool die = false;
	void FixedUpdate () {

		if(die==false)
			chkDistance ();


	}
	void chkDistance(){
		float dst = Vector3.Distance (transform.position, stage3PlayerControl.instance.player.transform.position);

		float same = transform.position.x - stage3PlayerControl.instance.player.transform.position.x;
		if (Mathf.Abs (same)>1) {
			if (dst < range) {
				Vector3 scale = transform.localScale;
				if ((int)transform.position.x > (int)stage3PlayerControl.instance.player.transform.position.x) {
					transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
					scale.x = Mathf.Abs (scale.x);
					transform.localScale = scale;
				} else {
					transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
					scale.x = -Mathf.Abs (scale.x);
					transform.localScale = scale;
				}
			}

		}
	}

	void OnCollisionEnter2D(Collision2D	 col){
		if (col.gameObject.tag == "Stone"&&col.gameObject.transform.position.y>transform.position.y) {
			GlobalAudioManager.instance.Lion_dSound ();
			gameObject.tag = "Ground";
			die = true;
			Destroy (col.gameObject);
		}
	}
}
