using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weaponMod
{
    internal interface IScope
    {
        GameObject ScopeInstance { get; }
        Transform BulletTransform { get; }
    }
}
