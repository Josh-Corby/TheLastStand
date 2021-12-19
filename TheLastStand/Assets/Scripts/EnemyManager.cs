using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    //Storage used for targets and spawn points
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    //this list currently serves no purpose as there is only one enemy type but it could have use in the future
    public List<GameObject> enemies;

    //how long the spawner waits to spawn another enemy
    public float spawnDelay = 1f;

    void Update()
    {
        //Press L key to spawn a random target at a random spawn location
        //if (Input.GetKeyDown(KeyCode.L))
            SpawnEnemy();
    }

    // function used to spawn enemies at a random spawn point with a delay, until a wave is fully spawned
    public IEnumerator SpawnWithDelay()
    {
        
        for (int i = 0; i < _GM.totalEnemies; i++)
        {
            //Get a random enemy to spawn
            int rndEnemy = Random.Range(0, enemyTypes.Length);
            //Get a random spawn point to spawn at
            int rndSpawn = Random.Range(0, spawnPoints.Length);
            //Instantiate a random enemy at a random spawn point
            GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
            //Add the enemy to the enemies list
            enemies.Add(enemy);
            //Wait for the spawn delay
            yield return new WaitForSeconds(spawnDelay);
            //Run the coroutine again
        }
    }


    //This function spawns a random target type at a random spawn point
    void SpawnEnemy()
    {
        //Get a random target to spawn
        int rndEnemy = Random.Range(0, enemyTypes.Length);
        //Get a random spawn point to spawn at
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        //Instantiate a random target at a random spawn point
        GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        //Add the target to the targets list
        enemies.Add(enemy);
    }


    //When a target dies, destroy it, remove it from the list, and update UI for how many enemies there are
    public void DestroyEnemy(GameObject _enemy)
    {
        Destroy(_enemy);
        enemies.Remove(_enemy);
    }

 

}
