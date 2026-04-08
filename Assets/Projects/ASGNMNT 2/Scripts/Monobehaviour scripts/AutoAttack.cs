using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public Transform targetTransform
    {
        get { return _targetTransform; }
        set
        {
            if (value == null)
            {
                //destroy the object and stop running the script incase the target dies before the auto reaches them
                Destroy(gameObject); return;
            }
            _targetTransform = value;
        }
    }
    private Transform _targetTransform;
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
        if(targetTransform == null) 
        { 
            Destroy(gameObject); return;
        }
        Vector3 displacementToTarget = targetTransform.position - transform.position;
        transform.position += displacementToTarget.normalized * autoBaseSpeed * speed * Time.deltaTime;
        ApproachedTarget();
    }

    void ApproachedTarget()
    {
        Vector3 displacement = targetTransform.position - transform.position;
        if (displacement.magnitude < hitThreshold)
        {
            targetTransform.GetComponent<BaseStats>().health -= damage;
            Destroy(gameObject);
        }
    }
}
