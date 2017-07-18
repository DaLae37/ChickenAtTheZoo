using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4Lion : MonoBehaviour {

    public float speed = 1f;
    public float range = 10f;
    public int HP = 3;
    public GameObject dead;
    public GameObject spin;
    public bool isTacked = false;
    public int Tracked;
    void FixedUpdate()
    {
        if (isTacked == false)
        {
            if (!stage4PlayerControl.instance.playerchk[3])
            {
                float dst = Vector3.Distance(transform.position, stage4PlayerControl.instance.playerList[3].transform.position);
                if (dst < range)
                {
                    isTacked = true;
                    Tracked = 3;
                }
            }
        }

        chkDistance();
    }
    void chkDistance()
    {
        if (!stage4PlayerControl.instance.playerchk[Tracked])
        {
            float dst = Vector3.Distance(transform.position, stage4PlayerControl.instance.playerList[Tracked].transform.position);

            float same = transform.position.x - stage4PlayerControl.instance.playerList[Tracked].transform.position.x;
            if (Mathf.Abs(same) > 1)
            {
                if (dst < range)
                {
                    Vector3 scale = transform.localScale;
                    if ((int)transform.position.x > (int)stage4PlayerControl.instance.playerList[Tracked].transform.position.x)
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

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stone" && col.gameObject.transform.position.y > transform.position.y)
        {
            HP--;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Stone" && col.gameObject.transform.position.y > transform.position.y && HP == 0)
        {
            Instantiate(dead, transform.position, Quaternion.identity);
            transform.Translate(new Vector3(-0.2f, 0.7f, 0));
            Instantiate(spin, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            stage4PlayerControl.instance.isGameClear = true;
        }
    }
}
