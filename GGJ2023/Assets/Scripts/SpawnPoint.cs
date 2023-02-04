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

    public void Spawn()
    {
        Debug.Log("Spawning Enemy");
        var spawnedEnemy = Instantiate(spawnedEnemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemy.targetRoot = reachableRoots[Random.Range(0, reachableRoots.Length)];
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (var root in reachableRoots)
        {
            Gizmos.DrawLine(transform.position, root.transform.position);
        }
    }*/

}
