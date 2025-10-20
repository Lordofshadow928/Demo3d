using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public int spawnQuantity;
    public float spawnInterval;
    public Transform spawnPoint;


    private bool isRunning;
#if Unity_Editor
using UnityEditor;
#endif

#if Unity_Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
#endif


    private void OnTriggerEnter(Collider other)
    {
        if(!isRunning && other.CompareTag("Player"))
        {
            isRunning = true;
            StartCoroutine(SpawnZombiesByTimes());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isRunning && other.CompareTag("Player"))
        {
            isRunning = false;
            StopAllCoroutines();
        }
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
