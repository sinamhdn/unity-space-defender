using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemt Wave Config Scriptable Object")]
public class WaveConfig : ScriptableObject
{
    [Header("Enemy List")]
    [SerializeField] Enemy[] enemy;
    [SerializeField][Range(0, 100)] float[] enemySpawnRandomness;

    [Header("Spawn Stats")]
    [SerializeField] GameObject path;
    [SerializeField] int enemyCount = 5;
    [SerializeField] float spawnDelay = 0.5f;
    [SerializeField] float moveSpeed = 2f;

    public Enemy[] GetEnemyPrefabs() { return enemy; }

    public float[] GetEnemySpawnRandomness() { return enemySpawnRandomness; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in path.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public int GetEnemyCount() { return enemyCount; }

    public float GetEnemySpawnDelay() { return spawnDelay; }


    public float GetEnemyMoveSpeed() { return moveSpeed; }
}
