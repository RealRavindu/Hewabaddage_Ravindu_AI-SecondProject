using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    private BaseStats stats;
    private float health;
    private float regenRate;
    void Start()
    {
        stats = GetComponent<BaseStats>();
        health = stats.health;
        regenRate = stats.regenRate;
    }

    // Update is called once per frame
    void Update()
    {
        health += regenRate * Time.deltaTime;
    }
}
