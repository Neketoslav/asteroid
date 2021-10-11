using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class AsteroidFactory : IEnemyFactory
{
    public Enemy Create(Health hp)
    {
        var enemy = Object.Instantiate(Resources.Load<Asteroid>("Asteroid"));
        enemy.DependencyInjectHealth(hp);
        return enemy;
    }
}
