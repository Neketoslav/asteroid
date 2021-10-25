using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

internal sealed class EnemyPool
{
    private readonly Dictionary<string, HashSet<Enemy>> enemyPool;
    private readonly int capacityPool;
    private Transform rootPool;


    public EnemyPool(int capacityPool)
    {
        enemyPool = new Dictionary<string, HashSet<Enemy>>();
        this.capacityPool = capacityPool;
        if (!rootPool)
        {
            rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
        }
    }

    public Enemy GetEnemy(string type)
    {
        Enemy result;
        switch (type)
        {
            case "Asteroid":
                result = GetAsteroid(GetListEnemies(type));
                break;
            case "FireAsteroid":
                result = GetFireAsteroid(GetListEnemies(type));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
        }

        return result;
    }

    private HashSet<Enemy> GetListEnemies(string type)
    {
        return enemyPool.ContainsKey(type) ? enemyPool[type] : enemyPool[type] = new HashSet<Enemy>();
    }

    private Enemy GetAsteroid(HashSet<Enemy> enemies)
    {
        var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        if (enemy == null)
        {
            var laser = Resources.Load<Asteroid>("Asteroid");
            for (var i = 0; i < capacityPool; i++)
            {
                var instantiate = Object.Instantiate(laser);
                ReturnToPool(instantiate.transform);
                enemies.Add(instantiate);
            }

            GetAsteroid(enemies);
        }
        enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        return enemy;
    }
    private Enemy GetFireAsteroid(HashSet<Enemy> enemies)
    {
        var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        if (enemy == null)
        {
            var laser = Resources.Load<FireAsteroid>("FireAsteroid");
            for (var i = 0; i < capacityPool; i++)
            {
                var instantiate = Object.Instantiate(laser);
                ReturnToPool(instantiate.transform);
                enemies.Add(instantiate);
            }

            GetAsteroid(enemies);
        }
        enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
        return enemy;
    }
    private void ReturnToPool(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.gameObject.SetActive(false);
        transform.SetParent(rootPool);
    }

    public void RemovePool()
    {
        Object.Destroy(rootPool.gameObject);
    }
}


