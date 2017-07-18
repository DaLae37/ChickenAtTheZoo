using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class stage4Player : MonoBehaviour {

    void Awake()
    {

    }

    void Start()
    {
        GlobalAudioManager.instance.StartSound();
    }
    void Update()
    {
        if (transform.position.y < -11)
            SceneManager.LoadScene("gameOverScene");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Escape")
        {
            GlobalAudioManager.instance.PotalSound();
            if (this.ToString().Equals("player1 (Player)"))
            {
                stage4PlayerControl.instance.playerchk[0] = true;
                if (!stage4PlayerControl.instance.playerchk[1])
                    stage4PlayerControl.instance.ctrPlayerIndex = 1;
                else if (!stage4PlayerControl.instance.playerchk[2])
                    stage4PlayerControl.instance.ctrPlayerIndex = 2;
                Destroy(stage4PlayerControl.instance.playerList[0]);
            }
            else if (this.ToString().Equals("player2 (Player)"))
            {
                stage4PlayerControl.instance.playerchk[1] = true;
                if (!stage4PlayerControl.instance.playerchk[2])
                    stage4PlayerControl.instance.ctrPlayerIndex = 2;
                else if (!stage4PlayerControl.instance.playerchk[0])
                    stage4PlayerControl.instance.ctrPlayerIndex = 0;
                Destroy(stage4PlayerControl.instance.playerList[1]);
            }
            else if (this.ToString().Equals("player3 (Player)"))
            {
                stage4PlayerControl.instance.playerchk[2] = true;
                if (!stage4PlayerControl.instance.playerchk[0])
                    stage4PlayerControl.instance.ctrPlayerIndex = 0;
                else if (!stage4PlayerControl.instance.playerchk[1])
                    stage4PlayerControl.instance.ctrPlayerIndex = 1;
                Destroy(stage4PlayerControl.instance.playerList[2]);
            }
            Destroy(collision.gameObject);
            stage4PlayerControl.instance.rb = stage4PlayerControl.instance.playerList[stage4PlayerControl.instance.ctrPlayerIndex].GetComponent<Rigidbody2D>();
            if (stage4PlayerControl.instance.playerchk[0] && stage4PlayerControl.instance.playerchk[1] && stage4PlayerControl.instance.playerchk[2])
            {
                SceneManager.LoadScene("clearScene");
            }
        }
        else if (collision.collider.tag == "Lion")
        {
            SceneManager.LoadScene("gameOverScene");
        }
        else if (collision.collider.tag == "Player" || collision.collider.tag == "Stone" || collision.collider.tag == "Ground")
        {
            GlobalAudioManager.instance.GroundSound();
            if (this.ToString().Equals("player1 (stage4Player)"))
            {
                stage4PlayerControl.instance.isJumping[0] = false;
                stage4PlayerControl.instance.isDashing[0] = false;
            }
            else if (this.ToString().Equals("player2 (stage4Player)"))
            {
                stage4PlayerControl.instance.isJumping[1] = false;
                stage4PlayerControl.instance.isDashing[1] = false;
            }
            else if (this.ToString().Equals("player3 (stage4Player)"))
            {
                stage4PlayerControl.instance.isJumping[2] = false;
                stage4PlayerControl.instance.isDashing[2] = false;
                stage4PlayerControl.instance.doubleJum = false;
            }
            else if (this.ToString().Equals("player4 (stage4Player)"))
            {
                stage4PlayerControl.instance.isJumping[3] = false;
                stage4PlayerControl.instance.isDashing[3] = false;
            }
            stage4PlayerControl.instance.rb.velocity = new Vector3(0, 0, 0);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Crocodile")
        {
            SceneManager.LoadScene("gameOverScene");
        }
    }
}
