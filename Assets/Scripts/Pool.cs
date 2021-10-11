using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Pool
{
    private readonly Stack<GameObject> stack = new Stack<GameObject>();
    private readonly GameObject prefab;
    private readonly Transform root;

    public Pool(GameObject prefab)
    {
        this.prefab = prefab;
        root = new GameObject($"[{prefab.name}]").transform;
    }

    public GameObject Pop()
    {
        GameObject go;
        if(stack.Count == 0)
        {
            go = Object.Instantiate(prefab);
            go.name = prefab.name;
        }
        else
        {
            go = stack.Pop();
        }
        go.SetActive(true);
        go.transform.SetParent(null);
        return go;
    }
    public void Push(GameObject go)
    {
        stack.Push(go);
        go.transform.SetParent(root);
        go.SetActive(false);
    }
    public void Dispose()
    {
        for(var i = 0; i < stack.Count; i++)
        {
            var gameObject = stack.Pop();
            Object.Destroy(gameObject);
        }
        Object.Destroy(root.gameObject);
    }

}




     
