using UnityEngine;
using UnityEngine.UI;

public class BaseStats : MonoBehaviour
{
    public StartingStats startingStats;
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
    public float health
    {
        get { return _health; }
        set
        {
            _health = value;
            _healthSlider.value = health;
        }
    }

    private float _health;

    public float attackSpeed;
    public float range;
    public float attackDamage;
    public float abilityPower;
    public float moveSpeed;
    public Material blueMat, redMat;
    private Slider _healthSlider;

    private void Start()
    {
        _healthSlider = transform.GetChild(0).GetChild(1).GetComponent<Slider>();
        health = _healthSlider.maxValue = startingStats.health;
        attackSpeed = startingStats.attackSpeed;
        range = startingStats.range;
        attackDamage = startingStats.attackDamage;
        abilityPower = startingStats.abilityPower;
        moveSpeed = startingStats.moveSpeed;
        //3 means that this obj shouldnt get a team assigned to it, and it will automatically be assigned by whatever is spawning it. So it is neutral.
        if(startingStats.team != 3) team = startingStats.team;


    }
}
