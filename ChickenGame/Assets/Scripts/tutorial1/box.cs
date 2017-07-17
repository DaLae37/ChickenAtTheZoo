using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D	 col){
		if (col.gameObject.tag == "Player") {
			GlobalAudioManager.instance.StoneSound ();
		}
	}
}
