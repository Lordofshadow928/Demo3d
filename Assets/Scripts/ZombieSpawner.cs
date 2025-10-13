using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public int spawnQuantity;
    public float spawnInterval;
    public float radius;

#if Unity_Editor
using UnityEditor;
#endif

#if Unity_Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.9f);
        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    }
#endif

    private void Start()
    {
        StartCoroutine(SpawnZombiesByTimes());
    }

    private IEnumerator SpawnZombiesByTimes()
    {
        while(spawnQuantity > 0)
        {
            SpawnZombies();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombies()
    {
        Instantiate(ZombiePrefab, transform.position, transform.rotation);
        spawnQuantity--;
    }
}
