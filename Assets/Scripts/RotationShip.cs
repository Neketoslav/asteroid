using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationShip : IRotation
{
    private readonly Transform transform;
    public RotationShip(Transform transform)
    {
        this.transform = transform;
    }

    public void Rotation(Vector3 direction)
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
