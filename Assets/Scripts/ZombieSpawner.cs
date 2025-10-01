using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float radius;
    public int spawnCount;
    public float spawnInterval;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    }
    private void Start()
    {
        StartCoroutine(SpawnZombiesByTime());
    }

    private IEnumerator SpawnZombiesByTime()
    {
        while (spawnCount > 0)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        spawnCount--;
    }
}
