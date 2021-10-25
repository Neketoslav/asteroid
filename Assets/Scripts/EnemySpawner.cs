using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemySpawner : MonoBehaviour
{
    private Spawn[] listSpawn;
    private ScoreScreen scoreScreen;
    private DisplayMessage displayMessage;
  
    private int indexSpawn;
    private int indexEnemy;
    private int countPoints;

    private bool isSpawning = false;

    public void Start()
    {
        scoreScreen = new ScoreScreen();
        displayMessage = new DisplayMessage();
        listSpawn = Object.FindObjectsOfType<Spawn>();
    }

    public void Update() //Не получается вынести в GameManager, ругается на корутину
    {     
        if (!isSpawning)
        {
            isSpawning = true;

            StartCoroutine(SpawnObject(Random.Range(2, 5)));
        }
    }
    IEnumerator SpawnObject(float seconds)
    {
        Debug.Log(seconds + " секунд до спавна");
        indexSpawn = Random.Range(0, listSpawn.Length);
        indexEnemy = Random.Range(1, 3);

        yield return new WaitForSeconds(seconds);
        if (indexEnemy == 1)
        {
            var enemy = Enemy.CreateAsteroidEnemy(new Health(100f, 100f));
            enemy.transform.position = listSpawn[indexSpawn].transform.position;
            enemy.OnPointChange += OnPointChange;
            enemy.DeathLog += DeathLog;
        }
        if(indexEnemy == 2)
        {
            var enemy = Enemy.CreateFireAsteroidEnemy(new Health(100f, 100f));
            enemy.transform.position = listSpawn[indexSpawn].transform.position;
            enemy.OnPointChange += OnPointChange;
            enemy.DeathLog += DeathLog;
        }

        isSpawning = false;
    }
    private void OnPointChange(int value)
    {
        countPoints += value;
        scoreScreen.Display(countPoints);
    }
    private void DeathLog(string name)
    {
        displayMessage.Display(name);
    }
}
