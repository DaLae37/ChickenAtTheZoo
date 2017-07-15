using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightter : MonoBehaviour {
    public Sprite usedButton;
    public GameObject skyBlock;
    public GameObject player;
    public bool chk = false;
    public bool isMove = false;
    private float time = 0.0f;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && chk == false && col.transform.position.y > transform.position.y + 0.2f)
        {
            chk = true;
            isMove = true;
            player.transform.SetParent(skyBlock.transform);
            gameObject.GetComponent<SpriteRenderer>().sprite = usedButton;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
    void Update()
    {
        if (isMove)
        {
            skyBlock.transform.Translate(Vector3.up * 2.0f * Time.smoothDeltaTime);
            time += Time.deltaTime;
        }
        if (time >= 3f)
        {
            isMove = false;
            player.transform.SetParent(null);
        }
    }
}
