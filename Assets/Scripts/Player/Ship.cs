using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : IMove, IRotation
{
    private readonly IMove moveRealisation;
    private readonly IRotation rotationRealisation;

    public float force { get; protected set; }

    public Ship(IMove moveRealisation, IRotation rotationRealisation)
    {
        this.moveRealisation = moveRealisation;
        this.rotationRealisation = rotationRealisation;
    }

    public void Move(float horizontal, float vertical)
    {
        moveRealisation.Move(horizontal, vertical);
    }

    public void Rotation(Vector3 direction)
    {
        rotationRealisation.Rotation(direction);
    }
    
    public void AddAcceleration()
    {
        if (moveRealisation is Acceleration accelerationMove)
        {
            accelerationMove.AddAcceleration();
        }
    }
    public void RemoveAcceleration()
    {
        if (moveRealisation is Acceleration accelerationMove)
        {
            accelerationMove.RemoveAcceleration();
        }

    }
}
