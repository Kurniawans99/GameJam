using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;
    [SerializeField] private float maxSpawnDistance = 5f;
    private float timer;
    private float timerMax = 3f;
    private float spawnDistance = 10f;

    private void Update()
    {
        if (timer >= timerMax)
        {
            maxSpawnDistance = Random.Range(15f, 21f);
            float xPos = Mathf.Sin(Mathf.PI * 2 * Random.Range(0f, 1.1f)) * maxSpawnDistance;
            float zPos = Mathf.Cos(Mathf.PI * 2 * Random.Range(0f, 1.1f)) * maxSpawnDistance;

            if (zPos <= 15f && zPos >= -15f)
            {
                zPos += (zPos >= 0) ? spawnDistance : -spawnDistance;
            }


            Vector3 spawnPos = new(xPos, 0, zPos);
            Transform newEnemy = Instantiate(enemySO.enemyPrefabs[0], spawnPos, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().target = enemySO.target;

            timer = 0f;
        }
        else timer += Time.deltaTime;
    }
}
