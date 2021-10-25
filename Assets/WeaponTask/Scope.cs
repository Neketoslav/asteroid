using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weaponMod
{
    internal sealed class Scope : IScope
    {
        public GameObject ScopeInstance { get; }
        public Transform BulletTransform { get; }
        public Scope(GameObject ScopeInstance, Transform BulletTransform)
        {
            this.ScopeInstance = ScopeInstance;
            this.BulletTransform = BulletTransform;
        }
    }
}

