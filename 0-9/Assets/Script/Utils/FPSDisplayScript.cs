﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSDisplayScript : MonoBehaviour
{
    float timeA;
    public int fps;
    public int lastFPS;
    public GUIStyle textStyle;
    public Text fps_txt;
    // Use this for initialization
    void Start()
    {
        timeA = Time.timeSinceLevelLoad;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeSinceLevelLoad+" "+timeA);
        if (Time.timeSinceLevelLoad - timeA <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeA = Time.timeSinceLevelLoad;
            fps = 0;
        }
        fps_txt.text = lastFPS.ToString();
    }
    void OnGUI()
    {
      //  GUI.Label(new Rect(450, 5, 30, 30), "" + lastFPS, textStyle);
    }
}
