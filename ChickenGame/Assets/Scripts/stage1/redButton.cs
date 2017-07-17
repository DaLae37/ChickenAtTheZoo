using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redButton : MonoBehaviour {


	public Sprite usedButton;
	public GameObject rm;
	public GameObject lm;
	public GameObject open;
	public bool chk=false;

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player"&&chk==false&&col.transform.position.y>transform.position.y+0.2f) {
			chk=true;
			gameObject.GetComponent<SpriteRenderer> ().sprite = usedButton;


			Destroy (rm.gameObject);
			rm.transform.Translate (new Vector3 (1f, 0, 2));
			Instantiate (open, rm.transform.position, Quaternion.identity);

			Destroy (lm.gameObject);
			lm.transform.Translate (new Vector3 (-1f, 0, 2));
			Instantiate (open, lm.transform.position, Quaternion.identity);
		}
	}
}
