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
        startPoint.y = 0.1f;
        transform.forward = (endPoint - startPoint).normalized;
        CheckForCollisions();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPoint, endPoint, timePassed);
        timePassed += Time.deltaTime * speed;
        if(timePassed > 1) Destroy(gameObject);
    }

    private void CheckForCollisions()
    {
        RaycastHit[] detectedEnemyThings = Physics.RaycastAll(startPoint, (endPoint - startPoint).normalized, Vector3.Distance(endPoint, startPoint), enemyLayerMask);
        foreach (RaycastHit hit in detectedEnemyThings)
        {
            BaseStats stats = hit.collider.GetComponent<BaseStats>();
            Debug.Log("detected enemy thing by lazer: " + hit.collider.gameObject.name);
            if (stats != null)
            {
                stats.health -= damage;
            }
        }
    }
}
