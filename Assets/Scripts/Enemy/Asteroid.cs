using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
internal sealed class Asteroid : Enemy
{
    GameObject player;

    public float speed = 0.001f;

    public event Action<int> OnPointChange = delegate (int i) { };
    public event Action<string> DeathLog = delegate (string c) { };

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
        OnPointChange.Invoke(100);
        DeathLog.Invoke("Астероид");
    }
}