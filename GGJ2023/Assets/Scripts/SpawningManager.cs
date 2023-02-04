using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawners = new List<SpawnPoint>();
    public float SpawningIntervals;
    public float SpawningIntervalsDecrease;
    public int CurrentWave = 1;
    public int BaseSpawnAmount;
    [SerializeField, Range(0.1f, 1f)] private float SpawnIncreaseBetweenWaves;

    private void Start()
    {
        StartSpawning();
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < BaseSpawnAmount * (SpawnIncreaseBetweenWaves * CurrentWave + 1); i++) //loop for the amount of enemies you want to spawn
        {
            foreach (var item in spawners)
            {
                item.Spawn();
            }
            yield return new WaitForSecondsRealtime(SpawningIntervals);

        }
        CurrentWave++;
        
    }



}
