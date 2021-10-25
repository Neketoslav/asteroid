using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weaponMod
{
    internal interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }

    }
}