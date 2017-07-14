using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour {

	public float speed = 0.3f; 
	public float range = 10f;

	void FixedUpdate () {

		chkDistance ();


	}
	void chkDistance(){
		float dst = Vector3.Distance (transform.position, PlayerControl.instance.playerList[PlayerControl.instance.ctrPlayerIndex].transform.position);

		float same = transform.position.x - PlayerControl.instance.playerList [PlayerControl.instance.ctrPlayerIndex].transform.position.x;
		if (Mathf.Abs (same)>1) {
			if (dst < range) {
				Vector3 scale = transform.localScale;
				if ((int)transform.position.x > (int)PlayerControl.instance.playerList [PlayerControl.instance.ctrPlayerIndex].transform.position.x) {
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
}
