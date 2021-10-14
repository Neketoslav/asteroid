using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShot : MonoBehaviour, IShot
{
    private readonly Sprite sprite;
    private readonly Transform barrel;

    private float speed = 4f;
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
            var shot = new GameObject().SetName("Bullet").AddTransform(barrel).AddBoxCollider2D().AddBoxCollider2D().AddRigidbody2D(1.0f, 0.0f).AddSprite(sprite); //неполучилось задать размер пробовал через Tranform.scale

            shot.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }
}
