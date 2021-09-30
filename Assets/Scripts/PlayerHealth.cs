using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    public event Action Death;
    public event Action Hurt;

    private float health;
    private float damage;
    private PlayerHealth(float health)
    {
        this.health = health;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= damage;
        if (health > 0)
            Hurt();
        else
            Death();
    }
}
