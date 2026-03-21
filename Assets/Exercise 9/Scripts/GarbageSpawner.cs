using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    public GameObject garbagePrefab;
    public KeyCode keyToSpawnGarbage;
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
    }
}
