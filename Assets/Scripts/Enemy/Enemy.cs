using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
internal abstract class Enemy : MonoBehaviour
{
    public static IEnemyFactory Factory;
    public Health health;
    public static Asteroid CreateAsteroidEnemy (Health hp)
    {
        var enemy = Instantiate(Resources.Load<Asteroid>("Asteroid"));
        enemy.health = hp;
        return enemy;
    }
    public static FireAsteroid CreateFireAsteroidEnemy(Health hp)
    {
        var enemy = Instantiate(Resources.Load<FireAsteroid>("FireAsteroid"));
        enemy.health = hp;
        return enemy;
    }
    public void DependencyInjectHealth(Health hp)
    {
        health = hp;
    }
}
