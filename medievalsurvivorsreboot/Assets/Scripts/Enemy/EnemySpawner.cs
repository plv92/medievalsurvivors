using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;    //A list of groups of enemies to spawn in this wave
        public int waveQuota;   //The total number of enemies to spawn in this wave
        public float spawnInterval; //The interval at which to spawn enemies
        public int spawnCount;  //The number of enemies already spawned in this wave
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;  //The number of enemies of this type to spawn in this wave
        public int spawnCount;  //The number of enemies of this type already spawned in this wave
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;
    public int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer;
    public int enemiesAlive; 
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;
    public float waveInterval;

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints; 
    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }
        spawnTimer += Time.deltaTime;

        //If the wave is complete, move to the next wave
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }
    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.Log(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }
        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}
