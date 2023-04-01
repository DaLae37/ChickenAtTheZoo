using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1PlayerControl : MonoBehaviour {
	public static stage1PlayerControl instance;

	public GameObject []playerList = new GameObject[2];
	public Camera cm;
	public float speed = 4.0f;
	public float jump = 5.0f;

	public bool []isJumping = new bool[2];
	public bool []leftchk = new bool[2];
	public bool []rightchk = new bool[2];
	public bool onLionGround = false;

	//추가
	public bool []isClear = new bool[2];

	public bool doubleJum = false;

	public Rigidbody2D rb;
	public int ctrPlayerIndex = 0;

	public void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		for (int i = 0; i < 2; i++)
		{
			isJumping[i] = false;
			leftchk[i] = false;
			rightchk[i] = false;

			//추가
			isClear [i] = false;
		}
	}

	public void Start()
	{
		rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
	}


	public void FixedUpdate()
	{

		comMove();

		if (leftchk[ctrPlayerIndex] == true) {
			playerList [ctrPlayerIndex].transform.Translate (new Vector3 (-speed * Time.smoothDeltaTime, 0, 0));
		}
		if (rightchk[ctrPlayerIndex] == true) {
			playerList [ctrPlayerIndex].transform.Translate (new Vector3 (speed * Time.smoothDeltaTime, 0, 0));
		}
		cm.transform.position = new Vector3(playerList[ctrPlayerIndex].transform.position.x, playerList[ctrPlayerIndex].transform.position.y, cm.transform.position.z);
	}


	public void LeftDown()
	{
		audioManager.instance.ButtonSound ();
		leftchk[ctrPlayerIndex] = true;
		Vector3 scale = transform.localScale;
		scale.x = -Mathf.Abs (scale.x);
		playerList [ctrPlayerIndex].transform.localScale = scale;
	}
	public void LeftUp()
	{
		leftchk[ctrPlayerIndex] = false;
	}
	public void RightDown()
	{
		audioManager.instance.ButtonSound ();
		rightchk[ctrPlayerIndex] = true;
		Vector3 scale = transform.localScale;
		scale.x = Mathf.Abs (scale.x);
		playerList [ctrPlayerIndex].transform.localScale = scale;
	}
	public void RightUp()
	{
		rightchk[ctrPlayerIndex] = false;
	}

	public void JumpClick()
	{

		if (ctrPlayerIndex == 1) {
			if (isJumping[ctrPlayerIndex] == true && doubleJum == false) {
				audioManager.instance.JumpSound ();

				doubleJum = true;
				rb.velocity = new Vector3(0,jump, 0);
			}
			if (isJumping [ctrPlayerIndex] == false) {
				audioManager.instance.JumpSound ();
				isJumping [ctrPlayerIndex] = true;
				rb.velocity = new Vector3 (0, (jump), 0);
			}
		}
		else {
			if (isJumping[ctrPlayerIndex] == false)
			{	
				audioManager.instance.JumpSound ();
				isJumping [ctrPlayerIndex] = true;
				rb.velocity = new Vector3 (0, jump, 0);
			}
		}

	}
	public void changePlayer(){
        audioManager.instance.ChangeSound ();
        rightchk[ctrPlayerIndex] = false;
        leftchk[ctrPlayerIndex] = false;
        switch (ctrPlayerIndex)
		{
		case 0:
			if(isClear[1]==false)
				ctrPlayerIndex = 1;
			break;
		case 1:
			if(isClear[0]==false)
				ctrPlayerIndex = 0;
			break;
		}
		rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
	}



	public void comMove()
	{
		if (Input.GetKey("w") && isJumping[ctrPlayerIndex] == false)
		{
			isJumping[ctrPlayerIndex] = true;
			rb.velocity = new Vector3(0, jump, 0);
		}
		if (Input.GetKey("a"))
		{
			playerList[ctrPlayerIndex].transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, 0, 0));

		}
		if (Input.GetKey("d"))
		{
			playerList[ctrPlayerIndex].transform.Translate(new Vector3(speed * Time.smoothDeltaTime, 0, 0));
	    }
		if (Input.GetKey("r"))
		{
			switch (ctrPlayerIndex)
			{
			case 0:
				ctrPlayerIndex = 1;
				break;
			case 1:
				ctrPlayerIndex = 0;
				break;
			}
			rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
		}
	}
}
