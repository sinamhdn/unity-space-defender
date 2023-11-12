using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigList;
    [SerializeField] int initialWave = 0;
    [SerializeField] bool isLooping = false;
    bool isLastWaveDeployed = false;
    // System.Random random;
    // double weightAccumulated;

    private IEnumerator Start()
    {
        // weightAccumulated = 0;
        // random = new System.Random();
        do
        {
            //  var currentWave = waveConfigList[initialWave];
            yield return StartCoroutine(SpawnWaves());
        }
        while (isLooping);
    }

    private void Update()
    {
        if (isLastWaveDeployed && FindObjectsOfType<Enemy>().Length == 0)
        {
            FindObjectOfType<LevelController>().LoadGameComplete();
        }
    }

    private IEnumerator SpawnEnemiesInWave(WaveConfig waveConfig)
    {
        Enemy[] enemyList = waveConfig.GetEnemyPrefabs();
        float[] enemyProbabilityList = waveConfig.GetEnemySpawnRandomness();
        for (int enemyCount = 0; enemyCount < waveConfig.GetEnemyCount(); enemyCount++)
        {
            var newEnemy = Instantiate(
                enemyList[GetRandomSpawnIndex(enemyList, enemyProbabilityList)],
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<Pathfinder>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetEnemySpawnDelay());
        }
    }

    private IEnumerator SpawnWaves()
    {
        for (int waveIndex = initialWave; waveIndex < waveConfigList.Count; waveIndex++)
        {
            var currentWave = waveConfigList[waveIndex];
            // CalculateWeight(currentWave);
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
        isLastWaveDeployed = true;
    }

    // private void CalculateWeight(WaveConfig waveConfig)
    // {
    //     enemyList = waveConfig.GetEnemyPrefabs();
    //     for (int i = 0; i < enemyList.Length; i++)
    //     {
    //         double[] probablityList = waveConfig.GetEnemySpawnRandomness();
    //         if (i < probablityList.Length) weightAccumulated += probablityList[i];
    //         else weightAccumulated += 0;
    //         enemyList[i].weight = weightAccumulated;
    //     }
    // }
    // private int GetRandomEnemyIndex()
    // {
    //     double rand = random.NextDouble() * weightAccumulated;
    //     for (int i = 0; i < enemyList.Length; i++)
    //     {
    //         if (enemyList[i].weight >= rand)
    //         {
    //             return i;
    //         }
    //     }
    //     return 0;
    // }

    private int GetRandomSpawnIndex(Enemy[] enemyList, float[] enemyProbabilityList)
    {
        float random = Random.Range(0f, 1f);
        float percentageToAdd = 0f;
        float total = 0f;

        for (int i = 0; i < enemyProbabilityList.Length; i++)
        {
            total += enemyProbabilityList[i];
        }

        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyProbabilityList[i] / total + percentageToAdd >= random)
            {
                return i;
            }
            else
            {
                percentageToAdd += enemyProbabilityList[i] / total;
            }
        }

        return 0;
    }
}
