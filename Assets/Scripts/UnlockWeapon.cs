using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UnlockWeapon 
{
    public bool isUnlock { get; set; }

    public UnlockWeapon(bool isUnlock)
    {
        this.isUnlock = isUnlock;
    }
}
