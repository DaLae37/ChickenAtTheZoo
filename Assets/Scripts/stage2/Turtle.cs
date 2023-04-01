﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
    public bool isDrive;
    public bool isBack;
    public float x;
    public float y;
    public int pivot;
    void Start()
    {
        isDrive = false;
        isBack = false;
        x = transform.position.x;
        y = transform.position.y;
    }
    void FixedUpdate()
    {
        if (!isDrive && isBack)
        {
            if (x > transform.position.x)
            {
                pivot = 5;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                pivot = -5;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            transform.position = new Vector3(transform.position.x + pivot * Time.smoothDeltaTime , transform.position.y,transform.position.z);
            if (Mathf.Abs(transform.position.x - x) < 0.1)
                isBack = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            isDrive = true;
            isBack = false;
            x = transform.position.x;
            y = transform.position.y;
        }
        else if(collision.collider.tag == "Ground")
        {
            isDrive = false;
            if (x != transform.position.x)
                isBack = true;
            else
                isBack = false;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && isDrive)
        {
            transform.position = new Vector3(collision.transform.position.x, transform.position.y,transform.position.z);
            transform.localScale = new Vector3(-collision.transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isDrive = false;
            if (x != transform.position.x)
                isBack = true;
            else
                isBack = false;
        }
    }
}
