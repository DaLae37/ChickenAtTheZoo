using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soundSetting : MonoBehaviour
{
    public GameObject obj;
    public Text bgText;
    public Text eftText;
    public Slider back;
    public Slider effect;
    public void onClick()
    {
        if (obj.active == true)
            Hide();
        else
            unHide();
    }
    public void backChanged()
    {
        bgText.text = "배경 볼륨 : " + ((int)(back.value * 100)).ToString();
    }
    public void eftChanged()
    {
        eftText.text = "효과음 볼륨 : " + ((int)(effect.value*100)).ToString();
    }
    public void Hide()
    {
        PlayerPrefs.SetFloat("bgm", back.value);
        PlayerPrefs.SetFloat("eft", effect.value);
        obj.active = false;
    }
    public void unHide()
    {
        back.value = PlayerPrefs.GetFloat("bgm");
        effect.value = PlayerPrefs.GetFloat("eft");
        bgText.text = "배경 볼륨 : " + ((int)(back.value * 100)).ToString();
        eftText.text = "효과음 볼륨 : " + ((int)(effect.value * 100)).ToString();
        obj.active = true;
    }
}
