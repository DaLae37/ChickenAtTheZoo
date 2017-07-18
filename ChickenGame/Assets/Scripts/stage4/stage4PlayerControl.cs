using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
public class stage4PlayerControl : MonoBehaviour {
    public static stage4PlayerControl instance;

    public GameObject[] playerList = new GameObject[4];
    public Camera cm;
    public float speed = 4.0f;
    public float jump = 5.0f;
    public float dashSpeed = 10.0f;

    public bool[] isDashing = new bool[4];
    public bool[] isJumping = new bool[4];
    public bool[] leftchk = new bool[4];
    public bool[] rightchk = new bool[4];
    public bool onLionGround = false;
    public bool isGameClear = false;
    public bool isTimeClock = false;
    public bool[] playerchk = new bool[4];

    public bool doubleJum = false;

    public Rigidbody2D rb;
    public int ctrPlayerIndex = 0;
    Stopwatch st = new Stopwatch();
    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        for (int i = 0; i < 4; i++)
        {
            isDashing[i] = false;
            isJumping[i] = false;
            leftchk[i] = false;
            rightchk[i] = false;
        }
    }

    public void Start()
    {
        rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
    }


    public void FixedUpdate()
    {

        if (isGameClear == true && !isTimeClock)
        {
            st.Start();
            isTimeClock = true;
        }
        if (st.ElapsedMilliseconds >= 2000)
        {
            SceneManager.LoadScene("clearScene");
        }
        comMove();

        if (leftchk[ctrPlayerIndex] == true)
        {
            playerList[ctrPlayerIndex].transform.Translate(new Vector3(-speed * Time.smoothDeltaTime, 0, 0));
            if (dashSpeed > 0)
                dashSpeed = -dashSpeed;
        }
        if (rightchk[ctrPlayerIndex] == true)
        {
            playerList[ctrPlayerIndex].transform.Translate(new Vector3(speed * Time.smoothDeltaTime, 0, 0));
            if (dashSpeed < 0)
                dashSpeed = -dashSpeed;
        }
        cm.transform.position = new Vector3(playerList[ctrPlayerIndex].transform.position.x, playerList[ctrPlayerIndex].transform.position.y, cm.transform.position.z);
    }


    public void LeftDown()
    {
        GlobalAudioManager.instance.ButtonSound();
        leftchk[ctrPlayerIndex] = true;
        Vector3 scale = transform.localScale;
        scale.x = -Mathf.Abs(scale.x);
        playerList[ctrPlayerIndex].transform.localScale = scale;
    }
    public void LeftUp()
    {
        leftchk[ctrPlayerIndex] = false;
    }
    public void RightDown()
    {
        GlobalAudioManager.instance.ButtonSound();
        rightchk[ctrPlayerIndex] = true;
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        playerList[ctrPlayerIndex].transform.localScale = scale;
    }
    public void RightUp()
    {
        rightchk[ctrPlayerIndex] = false;
    }

    public void JumpClick()
    {
        if (ctrPlayerIndex == 1)
        {
            if (isJumping[ctrPlayerIndex] == true && isDashing[ctrPlayerIndex] == false)
            {
                GlobalAudioManager.instance.DashSound();
                rb.velocity = new Vector3(dashSpeed, 0, 0);
                isDashing[ctrPlayerIndex] = true;
            }
            if (isJumping[ctrPlayerIndex] == false)
            {
                GlobalAudioManager.instance.JumpSound();
                isJumping[ctrPlayerIndex] = true;
                rb.velocity = new Vector3(0, jump, 0);
            }
        }

        if (ctrPlayerIndex == 2)
        {
            if (isJumping[ctrPlayerIndex] == true && doubleJum == false)
            {
                GlobalAudioManager.instance.JumpSound();
                doubleJum = true;
                rb.velocity = new Vector3(0, jump, 0);
            }
            if (isJumping[ctrPlayerIndex] == false)
            {
                GlobalAudioManager.instance.JumpSound();
                isJumping[ctrPlayerIndex] = true;
                rb.velocity = new Vector3(0, (jump), 0);
            }
        }
        if(ctrPlayerIndex == 3)
        {
            if (isJumping[ctrPlayerIndex] == false)
            {
                GlobalAudioManager.instance.JumpSound();
                isJumping[ctrPlayerIndex] = true;
                rb.velocity = new Vector3(0, -jump, 0);
            }
        }
        else
        {
            if (isJumping[ctrPlayerIndex] == false)
            {
                GlobalAudioManager.instance.JumpSound();
                isJumping[ctrPlayerIndex] = true;
                rb.velocity = new Vector3(0, jump, 0);
            }
        }

    }
    public void changePlayer()
    {
        switch (ctrPlayerIndex)
        {
            case 0:
                if (!playerchk[1])
                    ctrPlayerIndex = 1;
                else if (!playerchk[2])
                    ctrPlayerIndex = 2;
                else if (!playerchk[3])
                    ctrPlayerIndex = 3;
                break;
            case 1:
                if (!playerchk[2])
                    ctrPlayerIndex = 2;
                else if (!playerchk[3])
                    ctrPlayerIndex = 3;
                else if (!playerchk[0])
                    ctrPlayerIndex = 0;
                break;
            case 2:
                if (!playerchk[3])
                    ctrPlayerIndex = 3;
                else if (!playerchk[0])
                    ctrPlayerIndex = 0;
                else if (!playerchk[1])
                    ctrPlayerIndex = 1;
                break;
            case 3:
                if (!playerchk[0])
                    ctrPlayerIndex = 0;
                else if (!playerchk[1])
                    ctrPlayerIndex = 1;
                else if (!playerchk[2])
                    ctrPlayerIndex = 2;
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
                    ctrPlayerIndex = 3;
                    break;
                case 3:
                    ctrPlayerIndex = 0;
                    break;
            }
            rb = playerList[ctrPlayerIndex].GetComponent<Rigidbody2D>();
        }
    }
}
