using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.collider.tag == "Player"||collision.collider.tag == "Ground") {
            if (this.ToString().Equals("player1 (Player)"))
            {
                PlayerControl.instance.isJumping[0] = false;
                PlayerControl.instance.isDashing[0] = false;
            }
            else if (this.ToString().Equals("player2 (Player)"))
            {
                PlayerControl.instance.isJumping[1] = false;
                PlayerControl.instance.isDashing[1] = false;
            }
            else if (this.ToString().Equals("player3 (Player)"))
            {
                PlayerControl.instance.isJumping[2] = false;
                PlayerControl.instance.isDashing[2] = false;
            }
			PlayerControl.instance.rb.velocity = new Vector3 (0, 0, 0);
        }
    }
}
