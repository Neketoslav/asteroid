using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class PoolView : IPoolView
{
    private readonly Dictionary<string, Pool> viewCache = new Dictionary<string, Pool>(capacity: 12);

    public void Instantiate(GameObject prefab)
    {
        if (!viewCache.TryGetValue(prefab.name, out Pool viewPool))
        {
            viewPool = new Pool(prefab);
            viewCache[prefab.name] = viewPool;
        }
        viewPool.Pop();
    }
    public void Destroy(GameObject value)
    {
        viewCache[value.name].Push(value);
    }
}
