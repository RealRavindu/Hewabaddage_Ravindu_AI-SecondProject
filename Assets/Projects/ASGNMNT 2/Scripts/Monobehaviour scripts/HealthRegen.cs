using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    private BaseStats stats;
    void Start()
    {
        stats = GetComponent<BaseStats>();
    }

    // Update is called once per frame
    void Update()
    {
        stats.health += stats.regenRate * Time.deltaTime;
    }
}
