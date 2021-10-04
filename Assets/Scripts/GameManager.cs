using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Reference reference;
    private PlayerController playerController;
    public void Start()
    {
        reference = new Reference();
         playerController = new PlayerController(reference.Player, reference.MainCamera);

        EnemyPool enemyPool = new EnemyPool(5);

        var enemy = enemyPool.GetEnemy("Asteroid");
        enemy.transform.position = Vector3.one;
        enemy.gameObject.SetActive(true);

        enemy = enemyPool.GetEnemy("FireAsteroid");
        enemy.transform.position = Vector3.one;
        enemy.gameObject.SetActive(true);

        //Enemy.CreateFireAsteroidEnemy(new Health(100f, 100f));

        //IEnemyFactory factory = new AsteroidFactory();
        //factory.Create(new Health(100f, 100f));

        //Enemy.Factory = factory;
        //Enemy.Factory.Create(new Health(100.0f, 100.0f));

    }
    public void FixedUpdate()
    {
        playerController.Execute();
    }

}
