using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerModel playerModel;
    public void Start()
    {
        playerModel = new PlayerModel();
    }
    public void FixedUpdate()
    {
        playerModel.PlayerControl(); //вылетает NullReferenceException, не могу понять в чем дело
    }
}
