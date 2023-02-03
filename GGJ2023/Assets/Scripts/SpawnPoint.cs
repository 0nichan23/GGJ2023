using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public Root[] reachableRoots;

    public Enemy spawnedEnemyPrefab;
    public float spawnTime;

    public ProgressBar timeToSpawnBar;

    public AnimationCurve multiplyOverTime;

    private float remainingTimeToSpawn;

    private void Start()
    {
        remainingTimeToSpawn = 0;
        timeToSpawnBar.maxProgress = spawnTime;
    }

    private void Update()
    {
        remainingTimeToSpawn -= Time.deltaTime;

        if (remainingTimeToSpawn <= 0)
        {
            Spawn();
            remainingTimeToSpawn = spawnTime * multiplyOverTime.Evaluate(Time.time);
        }
        timeToSpawnBar.SetProgress(remainingTimeToSpawn);
    }

    private void Spawn()
    {
        var spawnedEnemy = Instantiate(spawnedEnemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemy.targetRoot = reachableRoots.GetRandom();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (var root in reachableRoots)
        {
            Gizmos.DrawLine(transform.position, root.transform.position);
        }
    }

}
