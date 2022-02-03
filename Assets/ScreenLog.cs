using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLog : MonoBehaviour
{
    public Text logText;
    public static ScreenLog Instance { get; private set; }

    private int logCount = 0;

    void Awake()
    {
        if (!Instance)
            Instance = this;
    }
    private void Start()
    {
        logText.text = "";
        DontDestroyOnLoad(this.gameObject);
    }
    private void _log<T>(T msg)
    {
        if (logText)
            logText.text += msg + " " + Convert.ToString(logCount++) + "\n";
    }
    public static void Log<T>(T msg)
    {
        if (Instance)
            Instance._log<T>(msg);
        Debug.Log(msg);
    }
}
