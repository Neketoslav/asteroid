using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ProxyWeapon : IShot
{
    private readonly IShot shipShot;
    private readonly UnlockWeapon unlockWeapon;

    public ProxyWeapon(IShot shipShot, UnlockWeapon unlockWeapon)
    {
        this.shipShot = shipShot;
        this.unlockWeapon = unlockWeapon;
    }
    public void Shot()
    {
        if (unlockWeapon.isUnlock)
        {
            shipShot.Shot();
        }
        else
        {
            Debug.Log("Оружие сломано");
        }
    }
}
