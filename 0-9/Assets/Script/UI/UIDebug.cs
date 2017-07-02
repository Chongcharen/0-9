using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIDebug : MonoBehaviour {
    TextMeshProUGUI debug_txt;
    private void Awake()
    {
        debug_txt = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Events.OnDebugConsole += Events_OnDebugConsole;
    }
    private void OnDisable()
    {
        Events.OnDebugConsole -= Events_OnDebugConsole;
    }

    private void Events_OnDebugConsole(string message)
    {
        debug_txt.text = message;
    }

}
