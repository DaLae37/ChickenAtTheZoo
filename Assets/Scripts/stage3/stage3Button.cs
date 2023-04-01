using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3Button : MonoBehaviour {

	public Sprite usedButton;
	public GameObject m;
	public GameObject open;
	public bool chk=false;

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player"&&chk==false&&col.transform.position.y>transform.position.y) {
			GlobalAudioManager.instance.DoorSound ();
			chk=true;
			gameObject.GetComponent<SpriteRenderer> ().sprite = usedButton;


			Destroy (m.gameObject);
			m.transform.Translate (new Vector3 (1f, 0, 0));
			Instantiate (open, m.transform.position, Quaternion.identity);

		}
	}
}
