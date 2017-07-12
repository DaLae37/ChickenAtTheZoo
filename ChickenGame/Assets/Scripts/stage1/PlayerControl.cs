using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public static PlayerControl instance;

    public GameObject []playerList = new GameObject[3];
    public Camera cm;
    public float speed = 100f;
    public float jump = 7.0f;
	public float dashSpeed = 10.0f;

	public bool []isDashing = new bool[3];
    public bool []isJumping = new bool[3];
    public bool []leftchk = new bool[3];
    public bool []rightchk = new bool[3];
    public bool view = true;
    public bool onLionGround = false;

    public Rigidbody2D rb;
    public int ctrPlayerIndex = 0;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        for(int i=0; i<3; i++)
        {
            isDashing[i] = false;
            isJumping[i] = false;
            leftchk[i] = false;
            rightchk[i] = false;
        }
}

    void Start()
    {
        rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        
        comMove();

		if (leftchk[ctrPlayerIndex] == true) {
			playerList [ctrPlayerIndex].transform.Translate (new Vector3 (-speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed > 0)
				dashSpeed = -dashSpeed;
		}
		if (rightchk[ctrPlayerIndex] == true) {
			playerList [ctrPlayerIndex].transform.Translate (new Vector3 (speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed < 0)
				dashSpeed = -dashSpeed;
		}
		cm.transform.position = new Vector3(playerList[ctrPlayerIndex].transform.position.x, playerList[ctrPlayerIndex].transform.position.y, cm.transform.position.z);
    }


	void LeftDown()
    {
        leftchk[ctrPlayerIndex] = true;
        view = false;
		Vector3 scale = transform.localScale;
		scale.x = -Mathf.Abs (scale.x);
		playerList [ctrPlayerIndex].transform.localScale = scale;
    }
    void LeftUp()
    {
        leftchk[ctrPlayerIndex] = false;
    }
    void RightDown()
    {
        rightchk[ctrPlayerIndex] = true;
		view = true;
		Vector3 scale = transform.localScale;
		scale.x = Mathf.Abs (scale.x);
		playerList [ctrPlayerIndex].transform.localScale = scale;
    }
    void RightUp()
    {
        rightchk[ctrPlayerIndex] = false;
    }

    void JumpClick()
    {
        if (isJumping[ctrPlayerIndex] == false)
		{
			isJumping[ctrPlayerIndex] = true;
			rb.velocity = new Vector3(0, jump, 0);
        }
    }
	void changePlayer(){
		switch (ctrPlayerIndex)
		{
		case 0:
			ctrPlayerIndex = 1;
			break;
		case 1:
			ctrPlayerIndex = 2;
			break;
		case 2:
			ctrPlayerIndex = 0;
			break;
		}
		rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
	}

	void dash(){
		if (isJumping[ctrPlayerIndex] == true && isDashing[ctrPlayerIndex] == false) {
			rb.velocity = new Vector3(dashSpeed, 0, 0);
			isDashing[ctrPlayerIndex] = true;
		}
	}
  

    void comMove()
    {
        if (Input.GetKey("w") && isJumping[ctrPlayerIndex] == false)
        {
            isJumping[ctrPlayerIndex] = true;
            rb.velocity = new Vector3(0, jump, 0);
        }
        if (Input.GetKey("a"))
        {
            playerList[ctrPlayerIndex].transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed > 0)
				dashSpeed = -dashSpeed;
        }
        if (Input.GetKey("d"))
        {
            playerList[ctrPlayerIndex].transform.Translate(new Vector3(speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed < 0)
				dashSpeed = -dashSpeed;
        }
		if (Input.GetKey("r"))
		{
			switch (ctrPlayerIndex)
			{
			case 0:
				ctrPlayerIndex = 1;
				break;
			case 1:
				ctrPlayerIndex = 2;
				break;
			case 2:
				ctrPlayerIndex = 0;
				break;
			}
			rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
		}
    }
}
