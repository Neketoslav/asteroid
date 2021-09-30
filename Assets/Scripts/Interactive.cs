using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive 
{
    internal float health = 3.0f;

    public void Hurt()
    {
        if (health <= 0)
        {
            Debug.Log("You die");
        }
        else
        {
            health--;
        }
    }
}
