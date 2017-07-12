using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour {

	public float speed = 0.3f; 

	public bool view = true;

	private int touched = 0;



	void FixedUpdate () {
		//if (Player.instance.onLionGround == true) {
		//	if (((Player.instance.view == true) && (view == false))||((Player.instance.view == false) && (view == true))) {
		//	} else {
		//		LionMove();
		//	}
		//} else {
		//	LionMove();
		//}

	}

	void LionMove(){
		if (view == true) {
			transform.Translate (new Vector2 (speed * Time.smoothDeltaTime, 0));
		}
		if (view == false) {
			transform.Translate (new Vector2 (-speed * Time.smoothDeltaTime, 0));
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		touched++;
		if (touched >= 2) {
			if (view == true) {
				view = false;
				touched-=2;
			} else {
				view = true;
				touched--;
			}
		}
	}
}
