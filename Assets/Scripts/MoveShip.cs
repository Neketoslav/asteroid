using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : IMove
{
    private Rigidbody rb;
    private Vector2 direction;
    public float force { get; protected set; }

    public MoveShip(Rigidbody rb, float force)
    {
        this.rb = rb;
        this.force = force;
    }

    public void Move(float horizontal, float vertical)
    {
        Vector2 direction = new Vector2(horizontal, vertical);
        rb.AddForce(direction.normalized * force);
    }
}
