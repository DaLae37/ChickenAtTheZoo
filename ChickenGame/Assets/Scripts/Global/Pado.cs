using UnityEngine;
using System.Collections;

public class Pado : MonoBehaviour
{
    private float deltaX = 0.0f;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time.timeScale = 1;
        deltaX += Time.smoothDeltaTime;
        this.transform.Translate(Vector3.up * Mathf.Sin(deltaX * 7) * 0.02f);
    }
}