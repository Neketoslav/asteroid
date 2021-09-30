using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerModel : MonoBehaviour
{
    internal float force = 1.0f;
    internal float acceleration = 2.0f;
    internal float health = 3.0f;
    internal float forceShot = 1000.0f;

    internal Vector3 direction;

    internal Camera _camera;

    internal Rigidbody2D rb;
    internal Rigidbody2D rbRocket;

    internal IShot shipShot;
    internal Ship ship;
    internal Interactive interactive;

    [SerializeField] internal Transform barrel;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbRocket = Resources.Load<Rigidbody2D>("Rocket");
        _camera = Camera.main;
        var move = new Acceleration(rb, force, acceleration);
        var rotation = new RotationShip(transform);
        ship = new Ship(move, rotation);
        shipShot = new ShipShot(rbRocket, forceShot);
        interactive = new Interactive();
    }
    public void PlayerControl()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactive.Hurt();
    }
}
