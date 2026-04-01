using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public Transform targetTransform;
    public float speed, hitThreshold;

    private void Update()
    {
        Vector3 displacementToTarget =targetTransform.position - transform.position;
        transform.position += displacementToTarget.normalized * speed * Time.deltaTime;
        SelfDestruct(displacementToTarget.magnitude);
    }

    void SelfDestruct(float displacement)
    {
        if(displacement < hitThreshold) Destroy(gameObject);
    }
}
