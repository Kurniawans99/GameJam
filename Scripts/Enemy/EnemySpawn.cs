using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance { get; private set; }
    [SerializeField] private EnemySO enemySO;
    [SerializeField] private float maxSpawnDistance = 5f;
    private float timer;
    private float timerMax = 5f;
    private int enemySpawn;
    private int enemySpawnMax = 5;
    private float spawnDistance = 10f;
    private int difficultyUpgrade;
    private int difficultyUpgradeMax = 10;
    private void Awake()
    {
        Instance = this;
    }
    private float timer1 = 0f;
    private float interval = 10f;

    private void Update()
    {
        timer1 += Time.deltaTime;

        if (timer1 >= interval)
        {
            // Reset timer and execute your code

            // Your code here

            if (timerMax > 1f)
            {
                timerMax -= 0.5f;
            }

            enemySpawnMax += 1;
            timer1 = 0f;
        }
        if (timer >= timerMax && enemySpawn < enemySpawnMax)
        {
            maxSpawnDistance = Random.Range(15f, 21f);
            float xPos = Mathf.Sin(Mathf.PI * 2 * Random.Range(0f, 1.1f)) * maxSpawnDistance;
            float zPos = Random.Range(-10f, -15f);




            Vector3 spawnPos = new(xPos, 0, zPos);
            Transform newEnemy = Instantiate(enemySO.enemyPrefabs[0], spawnPos, Quaternion.identity);
            enemySpawn++;

            timer = 0f;
        }
        else timer += Time.deltaTime;
    }

    public void EnemyDecrease(int enemyDead)
    {
        enemySpawn -= enemyDead;
    }
}
