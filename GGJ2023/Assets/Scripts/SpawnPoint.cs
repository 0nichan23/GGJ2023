using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public Root[] reachableRoots;

    public Enemy spawnedEnemyPrefab;
    public float spawnSpeed;

    private float remainingTimeToSpawn;

    private void Start()
    {
        remainingTimeToSpawn = spawnSpeed;
    }

    private void Update()
    {
        remainingTimeToSpawn -= Time.deltaTime;

        if (remainingTimeToSpawn <= 0)
        {
            Spawn();
            remainingTimeToSpawn = spawnSpeed;
        }
    }

    private void Spawn()
    {
        var spawnedEnemy = Instantiate(spawnedEnemyPrefab, transform.position, Quaternion.identity);
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
