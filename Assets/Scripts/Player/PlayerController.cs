using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private readonly Player player;
    private readonly Camera mainCamera;
    public PlayerController(Player player, Camera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }
    public void Start()
    {

    }

    public void Execute()
    {
        player.Move();
    }
}
