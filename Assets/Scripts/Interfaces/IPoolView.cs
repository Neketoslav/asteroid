using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal interface IPoolView
{
    void Instantiate(GameObject prefab);
    void Destroy(GameObject value);
}