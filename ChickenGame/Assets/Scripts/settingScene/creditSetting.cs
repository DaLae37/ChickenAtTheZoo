using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditSetting : MonoBehaviour {
    public GameObject obj;
    public void onClick()
    {
        if (obj.active == true)
            Hide();
        else
            unHide();
    }
    public void Hide()
    {
        obj.active = false;
    }
    public void unHide()
    {
        obj.active = true;
    }
}
