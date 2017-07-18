using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4SkyBlock : MonoBehaviour {
    public static stage4SkyBlock instance;
    public Sprite originButton;
    public Sprite usedButton;
    public GameObject skyBlock;
    private GameObject player;
    public bool chk = false;
    public bool isMove = false;
    private float time = 0.0f;
    private void Start()
    {
        instance = this;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && chk == false && col.transform.position.y > transform.position.y + 0.2f)
        {
            time = 0.0f;
            GlobalAudioManager.instance.UpblockSound();
            chk = true;
            stage4UnderBlock.instance.chk = false;
            isMove = true;
            col.transform.SetParent(skyBlock.transform);
            player = col.gameObject;
        }
    }
    void FixedUpdate()
    {
        if (!chk)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = originButton;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = usedButton;
        }
        if (isMove)
        {
            skyBlock.transform.Translate(Vector3.up * 5.0f * Time.smoothDeltaTime);
            time += Time.deltaTime;
        }
        if (time >= 3f)
        {
            isMove = false;
            player.transform.SetParent(null);
        }
    }
}
