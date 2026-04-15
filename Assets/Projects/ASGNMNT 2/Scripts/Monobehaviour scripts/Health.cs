using UnityEngine;

public class Health : MonoBehaviour
{
    BaseStats stats;
    Animation animator;
    private void Start()
    {
        stats = GetComponent<BaseStats>();
        animator = GetComponent<Animation>();
    }
    public void OnDeath(entityType entity)
    {
        if(entity == entityType.Champion)
        {
            Debug.Log(gameObject.name + " has been slain.");
            stats.isAlive = false;
            if(stats.isPlayer) animator.Play("Death");
            else
            {
                Destroy(gameObject);
            }

        }
        else if (entity == entityType.Minion)
        {
            Debug.Log("+20 G");
            Destroy(gameObject);
        }
    }
}
