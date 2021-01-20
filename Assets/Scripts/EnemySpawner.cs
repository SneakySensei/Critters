using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    public Enemy[] enemies;

    //public GameObject blocky;

    // Start with no enermy
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Update()
    {
        // If no enemy is about to be created, start a new timer
        if (!isSpawning)
        {
            Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
            isSpawning = true;
        }
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        isSpawning = false;
        
        int sample = 100;
        int random = Random.Range(0, 100);

        for(int i = 0; i < enemies.Length; i++)
        {
            sample -= enemies[i].spawnChance;
            if (random >= sample && GameController.isGameRunning)
            {
                Instantiate(enemies[i].model, transform.position, Quaternion.identity);
            }
        }

        // Instantiate(enemies[0].model, transform.position, Quaternion.identity);
    }
}
