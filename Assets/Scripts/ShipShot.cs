using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShot : MonoBehaviour, IShot
{
    private readonly Rigidbody2D rbRocket;
    private readonly float forceShot;
    public ShipShot(Rigidbody2D rbRocket, float forceShot)
    {
        this.rbRocket = rbRocket;
        this.forceShot = forceShot;
    }
    public void Shot(Transform barrel)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shoot");
            var shot = Instantiate(rbRocket, barrel.position, barrel.rotation);
            shot.AddForce(barrel.up * forceShot);
        }
    }
}
