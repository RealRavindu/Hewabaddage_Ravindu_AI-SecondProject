using UnityEngine;

public class Health : MonoBehaviour
{
    public void OnDeath(entityType entity)
    {
        if(entity == entityType.Champion)
        {
            Debug.Log(gameObject.name + " has been slain.");
            Destroy(gameObject);
        }
        else if (entity == entityType.Minion)
        {
            Debug.Log("+20 G");
            Destroy(gameObject);
        }
    }
}
