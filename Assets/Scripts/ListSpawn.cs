using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ListSpawn : IEnumerator, IEnumerable
{
    private Spawn[] listSpawn;
    private int index = -1;

    public ListSpawn()
    {
        listSpawn = Object.FindObjectsOfType<Spawn>();
    }
    public bool MoveNext()
    {
        if (index == listSpawn.Length - 1)
        {
            Reset();
            return false;
        }

        index++;
        return true;
    }

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Reset() => index = -1;
    public object Current => listSpawn[index];
}
