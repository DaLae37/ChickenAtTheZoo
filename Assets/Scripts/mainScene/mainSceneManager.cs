using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;
using debug = UnityEngine.Debug;

public class mainSceneManager : MonoBehaviour
{
    public Text quitText;
    private int clickNum = 0;
    Stopwatch st = new Stopwatch();
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && clickNum == 0)
            {
                st.Start();
                quitText.text = "한번 더 클릭시 종료 됩니다";
                clickNum++;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && clickNum == 1)
            {
                Application.Quit();
            }
        }
        if (st.ElapsedMilliseconds >= 2000)
        {
            quitText.text = "";
            clickNum = 0;
            st.Reset();
        }
    }
}
