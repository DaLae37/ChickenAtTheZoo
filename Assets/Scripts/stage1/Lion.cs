﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour {

	public float speed = 0.3f; 
	public float range = 10f;
	public GameObject dead;
	public GameObject spin;

	void FixedUpdate () {

		chkDistance ();


	}
	void chkDistance(){
		float dst = Vector3.Distance (transform.position, stage1PlayerControl.instance.playerList[stage1PlayerControl.instance.ctrPlayerIndex].transform.position);

		float same = transform.position.x - stage1PlayerControl.instance.playerList [stage1PlayerControl.instance.ctrPlayerIndex].transform.position.x;
		if (Mathf.Abs (same)>1) {
			if (dst < range) {
				Vector3 scale = transform.localScale;
				if ((int)transform.position.x > (int)stage1PlayerControl.instance.playerList [stage1PlayerControl.instance.ctrPlayerIndex].transform.position.x) {
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
			audioManager.instance.Lion_dSound ();
			Destroy (col.gameObject);
			Instantiate (dead, transform.position, Quaternion.identity);
			transform.Translate (new Vector3 (-0.2f, 0.7f, 0));
			Instantiate (spin, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}

}
