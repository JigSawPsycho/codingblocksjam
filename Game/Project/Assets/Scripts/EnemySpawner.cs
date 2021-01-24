﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    float baseRepeatRate = 2.5f;
    float repeatTick = 0.0f;
    public static List<GameObject> enemies = new List<GameObject>();
    
    void Start()
    {
        Invoke(nameof(SpawnEnemy), baseRepeatRate);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, this.gameObject.transform.position, Quaternion.identity, this.transform);
        enemies.Add(enemy);

        repeatTick += 0.1f;

        if(repeatTick > 6.2f)
        {
            repeatTick = 0f;
        }

        Invoke(nameof(SpawnEnemy), Utility.SinGraphY(repeatTick, baseRepeatRate));
    }
}