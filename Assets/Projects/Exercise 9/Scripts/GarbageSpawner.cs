using NodeCanvas.Framework;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GarbageSpawner : MonoBehaviour
{
    public GameObject garbagePrefab;
    public KeyCode keyToSpawnGarbage;
    public List<Transform> spawnedGarbageList = new List<Transform>();

    void Update()
    {
        if (Input.GetKeyDown(keyToSpawnGarbage))
        {
            SpawnGarbage();
        }
    }

    void SpawnGarbage()
    {
        GameObject spawnedGarbage = Instantiate(garbagePrefab);
        spawnedGarbage.transform.position = transform.position;
        spawnedGarbageList.Add(spawnedGarbage.transform);
    }
}
