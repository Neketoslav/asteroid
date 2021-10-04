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

    internal IShot shipShot;
    internal Ship ship { get; private set; }

    [SerializeField] internal Transform barrel;

    private Player player;
    private Camera mainCamera;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbRocket = Resources.Load<Rigidbody2D>("Rocket");
        mainCamera = Camera.main;
        var move = new Acceleration(rb, force, acceleration);
        var rotation = new RotationShip(transform);
        ship = new Ship(move, rotation);
        shipShot = new ShipShot(rbRocket, forceShot);
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
        shipShot.Shot(barrel);
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
