using UnityEngine;
using System.Collections.Generic;
public class FloorScript : MonoBehaviour
{
    private GarbageOnFloor floor;
    private void Start()
    {
        floor = transform.parent.GetComponent<GarbageOnFloor>();

    }
    private void OnCollisionStay(Collision collision)
    {
        foreach (GameObject trash in floor.Trash)
        {
            if (collision.gameObject == trash)
            {
                print("trash is alr foudn in list");
                break;
            }
            floor.Trash.Add(collision.gameObject);
            print("Adding trash to list");
        }
    }

}
