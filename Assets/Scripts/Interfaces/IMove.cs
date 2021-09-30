using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    float force { get; }
    void Move(float horizontal, float vertical);
}
