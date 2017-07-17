using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aligay : MonoBehaviour {


	public float chkTime =0;
	public float wave = 0.005f;
	public float moveSpeed = 0.05f;

	public float speed = 0.3f; 
	public float range = 5f;
	public float openTime =0;

	public Sprite openMouse;
	public Sprite swiming;

	bool onPlayer =false;

	void Update () {
		
		chkDistance ();

		if (onPlayer == true) {
			openTime += Time.deltaTime;
		}
		if (openTime > 1f) {
			gameObject.tag = "Crocodile";
			gameObject.GetComponent<SpriteRenderer> ().sprite = openMouse;
			if (openTime > 3f) {
				onPlayer = false;
				openTime = 0;
			}
		} else {
			gameObject.tag = "Ground";
			gameObject.GetComponent<SpriteRenderer> ().sprite = swiming;
		}
	}

	void waving(){
		chkTime += Time.deltaTime;
		if((int)chkTime%2==0)
			transform.Translate(new Vector3(0,wave,0));
		else
			transform.Translate(new Vector3(0,-wave,0));
		
	}
	void move(){
		transform.Translate(new Vector3(-moveSpeed,0,0));
	}

	void chkDistance(){
		float dst = Vector3.Distance (transform.position, PlayerControl.instance.playerList[PlayerControl.instance.ctrPlayerIndex].transform.position);

		if (dst < range) {
			
		} else {

			waving ();
			move ();
		}
			
	}


	void OnCollisionEnter2D(Collision2D	 col){
		if (col.gameObject.tag == "Ground") {
			moveSpeed = -moveSpeed;
			Vector3 scale = transform.localScale;
			scale.x = -(scale.x);
			transform.localScale = scale;
		}
		if (col.gameObject.tag == "Player") {
			onPlayer = true;

		}
	}


}
