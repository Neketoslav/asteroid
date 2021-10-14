using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    internal float force = 1.0f;
    internal float acceleration = 2.0f;
    internal float health = 1.0f;
    internal float forceShot = 1000.0f;

    internal Vector3 direction;

    internal Rigidbody2D rb;
    internal Rigidbody2D rbRocket;

    [SerializeField] internal Sprite sprite;
    [SerializeField] internal Transform barrel;

    internal IShot shipShot;
    internal IShot weaponProxy;
    internal UnlockWeapon unlockWeapon;
    internal Ship ship { get; private set; }

    private Player player;
    private Camera mainCamera;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbRocket = Resources.Load<Rigidbody2D>("Rocket");
        sprite = Resources.Load<Sprite>("Bullet");
        mainCamera = Camera.main;
        var move = new Acceleration(rb, force, acceleration);
        var rotation = new RotationShip(transform);
        ship = new Ship(move, rotation);
        shipShot = new ShipShot(sprite, barrel);

        var unlockWeapon = new UnlockWeapon(false);  
        var weaponProxy = new ProxyWeapon(shipShot, unlockWeapon);
    }

    public void Move()
    {
        var direction = Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position);
        ship.Rotation(direction);
        ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ship.AddAcceleration();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ship.RemoveAcceleration();
        }
        //shipShot.Shot();
        weaponProxy.Shot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (CompareTag("Enemy"))
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                health--;
            }
        }

    }
}
