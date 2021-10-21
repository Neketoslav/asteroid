using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class FireAsteroid : Enemy
{
    GameObject player;

    private float speed = 0.002f;

    public event Action<int> OnPointChange = delegate (int i) { };

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }

    public override void ScoreLoot()
    {
        OnPointChange.Invoke(200);
    }
}
