using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class PrototypeEnemy
{
    private void Start()
    {
        Asteroid asteroid = new Asteroid
        {
            speed = 0.001f
        };

        Asteroid asteroidDataNew = asteroid.DeepCopy();
        asteroidDataNew.health.currentHealth = 200;

        Debug.Log(asteroid);
        Debug.Log(asteroidDataNew);
    }
}

