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

    internal Rigidbody rb;
    internal Rigidbody rbRocket;

    internal Sprite sprite;
    [SerializeField] internal Transform barrel;

    internal IShot shipShot;
    internal IShot weaponProxy;
    internal UnlockWeapon unlockWeapon;
    internal Ship ship { get; private set; }

    private Player player;
    private Camera mainCamera;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbRocket = Resources.Load<Rigidbody>("Rocket");
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
        shipShot.Shot();
        //weaponProxy.Shot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            if (health <= 0)
            {
                Debug.Log("death");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("damage");    
            }
        }
    }
}
