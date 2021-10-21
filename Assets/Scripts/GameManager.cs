using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Reference reference;
    private PlayerController playerController;
    private ScoreScreen scoreScreen;
    private EnemySpawner enemySpawner;

    private Spawn[] listSpawn;

    public void Start()
    {
        reference = new Reference();

        playerController = new PlayerController(reference.Player, reference.MainCamera);



        //Enemy.CreateAsteroidEnemy(new Health(100f, 100f));
        //Enemy.CreateFireAsteroidEnemy(new Health(100f, 100f));

        //EnemyPool enemyPool = new EnemyPool(5);

        //var enemy = enemyPool.GetEnemy("Asteroid");
        //enemy.transform.position = Vector3.one;
        //enemy.gameObject.SetActive(true);

        //enemy = enemyPool.GetEnemy("FireAsteroid");
        //enemy.transform.position = Vector3.one;
        //enemy.gameObject.SetActive(true);

        //enemy = enemyPool.GetEnemy("FireAsteroid");
        //enemy.transform.position = Vector3.one;
        //enemy.gameObject.SetActive(true);


        //IEnemyFactory factory = new AsteroidFactory();
        //factory.Create(new Health(100f, 100f));

        //Enemy.Factory = factory;
        //Enemy.Factory.Create(new Health(100.0f, 100.0f));

    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        playerController.Execute();
    }
}
