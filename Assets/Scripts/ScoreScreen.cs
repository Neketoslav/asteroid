using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreScreen
{
    private Text text;

    public ScoreScreen()
    {
        text = Object.FindObjectOfType<Text>();
    }

    public void Display(int value)
    {
        text.text = ToScore(value);
    }

    public string ToScore(float value)
    {
        int i = 0;

        while (value >= 1000)
        {
            i++;

            value /= 1000;
        }

        string suffix = string.Empty;

        switch (i)
        {
            case 1: suffix = "K";
                break;
            case 2: suffix = "M";
                break;
            case 3: suffix = "B";
                break;
            case 4: suffix = "T";
                break;
        }

        return $"{value}{suffix}";
    }
}
