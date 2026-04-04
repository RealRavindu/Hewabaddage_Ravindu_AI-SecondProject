using System.Collections;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject minionPrefab;
    public float team;
    public float waveSpawnTime;
    public float numberOfMinions;
    public float spawnInterval;
    private float timePassed;
    private Coroutine waveSpawningCR;
    private void Update()
    {
        Debug.Log(timePassed);
        if (timePassed == 0 )
        {
            //spawn minions
            if(waveSpawningCR == null) waveSpawningCR = StartCoroutine(spawnWave());

        }
        timePassed += Time.deltaTime;
        if (timePassed > waveSpawnTime) timePassed = 0;
    }

    private IEnumerator spawnWave()
    {
        int numberSpawned = 0;
        while(numberSpawned < numberOfMinions)
        {
            GameObject spawnedMinion = Instantiate(minionPrefab);
            spawnedMinion.GetComponent<BaseStats>().team = team;
            spawnedMinion.transform.position = transform.position;
            numberSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }

    }
}
