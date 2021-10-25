using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class DisplayMessage
{
    private Text text;

    public DisplayMessage()
    {
      text = Object.FindObjectOfType<DeathLog>().GetComponent<Text>();
    }

    public void Display(string name)
    {
        text.text = $"Вы уничтожили {name}!";
    }
}
