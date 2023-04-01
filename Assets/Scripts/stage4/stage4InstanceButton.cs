using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4InstanceButton : MonoBehaviour {
    static stage4InstanceButton instance;
    public Camera cm;
    public GameObject[] list = new GameObject[3];
    public GameObject[] stones = new GameObject[3];
    public GameObject stone;
    public Sprite originButton;
    public Sprite usedButton;
    public bool isActive = false;
    
    private void Start()
    {
        
        instance = this;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && !isActive && col.transform.position.y > transform.position.y + 0.2f)
        {
            GlobalAudioManager.instance.UpblockSound();
            isActive = true;
            cm.orthographicSize = 10;
        }
    }
  
    bool allStones()
    {
        for (int i = 0; i < 3; i++)
        {
            if (stones[i] != null && stones[i].transform.position.y > -1)
                return true;
        }
        return false;
    }
    void FixedUpdate()
    {
        if (!allStones())
        {
            if (isActive)
            {
                stones[0] = Instantiate(stone, list[0].transform);
                stones[0].transform.SetParent(list[0].transform);
                stones[1] = Instantiate(stone, list[1].transform);
                stones[1].transform.SetParent(list[0].transform);
                stones[2] = Instantiate(stone, list[2].transform);
                stones[2].transform.SetParent(list[0].transform);
            }
           
        }
        if (!isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = originButton;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = usedButton;
        }
    }
}
