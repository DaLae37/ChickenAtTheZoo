using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lions : MonoBehaviour {

    public float speed = 0.3f;
    public float range = 10f;
    public bool die = false;
    public bool isTacked = false;
    public int Tracked;
    void FixedUpdate()
    {
        if(isTacked == false)
        {
            for (int i = 0; i < 3; i++)
            {
                float dst = Vector3.Distance(transform.position, PlayerControl.instance.playerList[i].transform.position);
                if (dst < range)
                {
                    isTacked = true;
                    Tracked = i;
                }
            }

        }
        
        if (die == false && isTacked)
            chkDistance();
    }
    void chkDistance()
    {
        float dst = Vector3.Distance(transform.position, PlayerControl.instance.playerList[Tracked].transform.position);

        float same = transform.position.x - PlayerControl.instance.playerList[Tracked].transform.position.x;
        if (Mathf.Abs(same) > 1)
        {
            if (dst < range)
            {
                Vector3 scale = transform.localScale;
                if ((int)transform.position.x > (int)PlayerControl.instance.playerList[Tracked].transform.position.x)
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                    scale.x = Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
                else
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                    scale.x = -Mathf.Abs(scale.x);
                    transform.localScale = scale;
                }
            }
            else
                isTacked = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stone" && col.gameObject.transform.position.y > transform.position.y)
        {
            die = true;
            Destroy(col.gameObject);
        }
    }

}
