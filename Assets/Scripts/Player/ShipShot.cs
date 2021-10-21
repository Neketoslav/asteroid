using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShot : MonoBehaviour, IShot
{
    private readonly Sprite sprite;
    private readonly Transform barrel;

    private float lifeTime = 5.0f;
    public ShipShot(Sprite sprite, Transform barrel)
    {
        this.sprite = sprite;
        this.barrel = barrel;
    }
    public void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shoot");
            GameObject shot = new GameObject().SetName("Bullet").AddTransform(barrel).AddBoxCollider().AddRigidbody(1,0).AddScript().AddSprite(sprite);

            Destroy(shot, lifeTime);
        }
    }
}
