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
            bool coordsFound = false;
            //choose 2 random coords within 2 bounds
            while (!coordsFound)
            {
                Vector3 coords = ChooseRandomCoords();
                RaycastHit hit;
                Collision[] collisions = Physics.Raycast(coords, Vector3.down, 10, groundLayer, out hit);
            }
            //raycast to check whether its over the floor
            //if yes spawn, if not choose 2 random coords again and re-try.

        }
    }

    Vector3 ChooseRandomCoords()
    {
        return new Vector3(Random.Range(xCoordBounds.x, xCoordBounds.y),10, Random.Range(zCoordBounds.x, zCoordBounds.y));
    }
}
