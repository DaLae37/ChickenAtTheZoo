using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadLion : MonoBehaviour {


	public GameObject dead;
	float chkTime =0;
	void Start () {
		Destroy (this.gameObject,1f);
	}

	void Update () {
		chkTime += Time.deltaTime;
		if (chkTime > 1) {
			Instantiate (dead, transform.position, Quaternion.identity);
			chkTime = 0;
		}

	}
}
