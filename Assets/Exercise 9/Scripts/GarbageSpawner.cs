using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    public GameObject garbagePrefab;
    public KeyCode keyToSpawnGarbage;
    [SerializeField] Vector2 xCoordBounds, yCoordBounds;
    void Update()
    {
        if (Input.GetKeyDown(keyToSpawnGarbage))
        {
            //choose 2 random coords within 2 bounds
            ChooseRandomCoords();
            //raycast to check whether its over the floor
            //if yes spawn, if not choose 2 random coords again and re-try.

        }
    }

    Vector2 ChooseRandomCoords()
    {
        return new Vector2(Random.Range(xCoordBounds.x, xCoordBounds.y), Random.Range(yCoordBounds.x, yCoordBounds.y));
    }
}
