using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MoveShip
{
    private readonly float acceleration;
    public Acceleration(Rigidbody rb, float force, float acceleration) : base(rb, force)
    {
        this.acceleration = acceleration;
    }
    public void AddAcceleration()
    {
        force += acceleration;
    }
    public void RemoveAcceleration()
    {
        force -= acceleration;
    }
}
