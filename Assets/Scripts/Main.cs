using System;
using UnityEngine;

public class Main
{
    public static Main Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Main();
            }

            return instance;
        }
    }

    public int VisibleWidth
    {
        get;
        private set;
    }

    public int VisibleHeight
    {
        get;
        private set;
    }

    private static Main instance;

    private Main() {}

    public void Initialize()
    {
        Time.timeScale = 0;
        VisibleWidth = (int)Math.Round(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x) * 2;
        VisibleHeight = (int)Math.Round(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y) * 2;
    }
}
