using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class FireAsteroid : Enemy
{
    GameObject player;

    private float speed = 0.05f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }
}
