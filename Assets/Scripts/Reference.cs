using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference : MonoBehaviour
{
    private Player player;
    private Camera mainCamera;
    public Player Player
    {
        get
        {
            if (player == null)
            {
                var gameObject = Resources.Load<Player>("Player");
                player = Object.Instantiate(gameObject);
            }

            return player;
        }
    }
    public Camera MainCamera
    {
        get
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
            return mainCamera;
        }
    }

}
