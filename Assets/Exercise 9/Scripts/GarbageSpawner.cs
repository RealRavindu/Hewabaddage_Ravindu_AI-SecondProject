using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    public GameObject garbagePrefab;
    public KeyCode keyToSpawnGarbage;
    [SerializeField] Vector2 xCoordBounds, zCoordBounds;
    [SerializeField] LayerMask groundLayer;
    void Update()
    {
        if (Input.GetKeyDown(keyToSpawnGarbage))
        {
            SpawnGarbage();
        }
    }

    void SpawnGarbage()
    {
        //coordsFound bool will facilitate a while loop until set to true.
        bool coordsFound = false;
        Vector3 coords = new Vector3();

        while (!coordsFound)
        {
            //select a random x and z keeping y at 10.
            coords = ChooseRandomCoords();

            //raycast to check whether the selected coordinates are above the ground. If not, it will select 2 random coordinates again.
            if (Physics.Raycast(coords, Vector3.down, Mathf.Infinity, groundLayer)) coordsFound = true;

        }

        //spawn the garbage using the now selected coords.
        GameObject spawnedGarbage = Instantiate(garbagePrefab);
        spawnedGarbage.transform.position = coords;
    }

    Vector3 ChooseRandomCoords()
    {
        return new Vector3(Random.Range(xCoordBounds.x, xCoordBounds.y),10, Random.Range(zCoordBounds.x, zCoordBounds.y));
    }
}
