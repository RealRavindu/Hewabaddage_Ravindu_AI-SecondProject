using System.Transactions;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public LayerMask enemyLayerMask;
    private BaseStats stats;
    public float speed;
    private float damage;
    private Vector3 startPoint, endPoint;
    private float timePassed;
    public void initiate(Vector3 endPointTarg, float damageTarg)
    {
        damage = damageTarg;
        endPoint = endPointTarg;
        startPoint = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPoint, endPoint, timePassed);
        timePassed += Time.deltaTime * speed;
        if(timePassed > 1) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("LAzer met an object in general: " + other.gameObject.name);
        if (other.gameObject.layer == enemyLayerMask)
        {
            Debug.Log("LAzer met an object in blue team: " + other.gameObject.name);
            stats = other.GetComponent<BaseStats>();
            if(stats != null)
            {
                stats.health -= damage;
            }
        }
    }
}
