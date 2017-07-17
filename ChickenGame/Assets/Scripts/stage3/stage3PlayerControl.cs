using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3PlayerControl : MonoBehaviour {
	public static stage3PlayerControl instance;

	public GameObject player;
	public Camera cm;
	public float speed = 4.0f;
	public float jump = 5.0f;
	public float dashSpeed = 10.0f;

	public bool isDashing=false;
	public bool isJumping = false;
	public bool leftchk = false;
	public bool rightchk = false;

	public Rigidbody2D rb;

	public void Awake()
	{
		if (!instance)
		{
			instance = this;
		}	}

	public void Start()
	{
		rb = player.GetComponent<Rigidbody2D>();
	}


	public void FixedUpdate()
	{

		comMove();

		if (leftchk == true) {
			player.transform.Translate (new Vector3 (-speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed > 0)
				dashSpeed = -dashSpeed;
		}
		if (rightchk == true) {
			player.transform.Translate (new Vector3 (speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed < 0)
				dashSpeed = -dashSpeed;
		}
		cm.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cm.transform.position.z);
	}


	public void LeftDown()
	{
		GlobalAudioManager.instance.ButtonSound ();
		leftchk = true;
		Vector3 scale = transform.localScale;
		scale.x = -Mathf.Abs (scale.x);
		player.transform.localScale = scale;
	}
	public void LeftUp()
	{
		leftchk = false;
	}
	public void RightDown()
	{
		GlobalAudioManager.instance.ButtonSound ();
		rightchk = true;
		Vector3 scale = transform.localScale;
		scale.x = Mathf.Abs (scale.x);
		player.transform.localScale = scale;
	}
	public void RightUp()
	{
		rightchk = false;
	}

	public void JumpClick()
	{
			if (isJumping == true && isDashing == false) {
				GlobalAudioManager.instance.DashSound ();
				rb.velocity = new Vector3(dashSpeed, 0, 0);
				isDashing = true;
			}
			if (isJumping == false)
			{
				GlobalAudioManager.instance.JumpSound ();
				isJumping  = true;
				rb.velocity = new Vector3 (0, jump, 0);
			}
	
	}

	public void comMove()
	{
		if (Input.GetKey("w") && isJumping == false)
		{
			isJumping = true;
			rb.velocity = new Vector3(0, jump, 0);
		}
		if (Input.GetKey("a"))
		{
			player.transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed > 0)
				dashSpeed = -dashSpeed;
		}
		if (Input.GetKey("d"))
		{
			player.transform.Translate(new Vector3(speed * Time.smoothDeltaTime, 0, 0));
			if (dashSpeed < 0)
				dashSpeed = -dashSpeed;
		}
	}
}
