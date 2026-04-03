using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public Transform targetTransform;
    public float speed, hitThreshold, damage, autoBaseSpeed;

    public void Init(float speedTarg, float damageTarg, Transform target, Vector3 startPos, Material allyMat)
    {
        speed = speedTarg;
        damage = damageTarg;
        targetTransform = target;
        transform.position = startPos;
        GetComponent<MeshRenderer>().material = allyMat;
        GetComponent<TrailRenderer>().material = allyMat;
    }
    private void Update()
    {
        Vector3 displacementToTarget =targetTransform.position - transform.position;
        transform.position += displacementToTarget.normalized* autoBaseSpeed * speed * Time.deltaTime;
        SelfDestruct(displacementToTarget.magnitude);
    }

    void SelfDestruct(float displacement)
    {
        if(displacement < hitThreshold) Destroy(gameObject);
    }
}
