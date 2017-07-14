using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour {

	public float speed = 0.3f; 
	public float range = 10f;


	void FixedUpdate () {
		float dst = Vector3.Distance (transform.position, PlayerControl.instance.playerList[PlayerControl.instance.ctrPlayerIndex].transform.position);

		if (dst < range) {
			if(transform.position.x > PlayerControl.instance.playerList[PlayerControl.instance.ctrPlayerIndex].transform.position.x)
				transform.Translate (new Vector3 (-speed*Time.deltaTime, 0, 0));
			else
				transform.Translate (new Vector3 (speed*Time.deltaTime, 0, 0));
		}
	}

}
