using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public float team
    {
        get
        {
            return _team;
        }
        set
        {
            _team = value;
            gameObject.layer = LayerMask.NameToLayer((value == 0) ? "BlueTeam" : "RedTeam");
            GetComponent<MeshRenderer>().material = (value == 0) ? blueMat : redMat;
        }
    }
    private float _team;
    public float health;
    public float attackSpeed;
    public float range;
    public float attackDamage;
    public float abilityPower;
    public float moveSpeed;
    public Material blueMat, redMat;
}
