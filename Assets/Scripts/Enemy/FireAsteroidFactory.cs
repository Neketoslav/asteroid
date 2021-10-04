using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class FireAsteroidFactory : IEnemyFactory
{
    public Enemy Create(Health hp)
    {
        var enemy = Object.Instantiate(Resources.Load<Asteroid>("FireAsteroid"));
        enemy.DependencyInjectHealth(hp);
        return enemy;
    }
}
