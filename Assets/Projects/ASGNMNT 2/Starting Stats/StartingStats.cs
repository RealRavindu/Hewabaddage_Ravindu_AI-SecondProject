using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "StartingStats", menuName = "Scriptable Objects/StartingStats")]
public class StartingStats : ScriptableObject
{
    public float team;
    public float health;
    public float regenRate;
    public float attackSpeed;
    public float range;
    public float attackDamage;
    public float abilityPower;
    public float moveSpeed;
    public entityType entity;
}
