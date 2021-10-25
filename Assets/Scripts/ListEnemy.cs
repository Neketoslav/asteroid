using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ListEnemy : IEnumerator, IEnumerable
{
    private Enemy[] enemies;
    private int index = -1;

    public ListEnemy()
    {
        enemies = Object.FindObjectsOfType<Enemy>();
    }

    public bool MoveNext()
    {
        if (index == enemies.Length - 1)
        {
            Reset();
            return false;
        }
        index++;
        return true;
    }

    public void Reset() => index = -1;

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public object Current => enemies[index];
}
