using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChampionController : MonoBehaviour
{
    public float speed;
    public LayerMask groundLayerMask, targetableLayerMask;
    private Vector3 moveToPos;
    private Rigidbody rb;
    public float arrivalThreshold;
   


    [Header("Auto variables")]
    private GameObject Target
    {
        get { return _Target; }
        set
        {
            if(value == null)
            {
                Debug.Log("value is null");
                currentlyAutoing = false;
                if(AutoCR != null)
                {
                    Debug.Log("stopping coroutine!");
                    autoSlider.gameObject.SetActive(false);
                    StopCoroutine(AutoCR);
                    AutoCR = null;
                }
            }
            _Target = value;
        }
    }
    private GameObject _Target;
    [SerializeField] bool currentlyAutoing;
    private BaseStats stats;
    public GameObject autoPrefab;
    public Slider autoSlider;
    private float autoTime;
    private Coroutine AutoCR;

    [Header("Q variables")]
    public float QCooldown;
    public float QRange;

    private void Start()
    {
        stats = GetComponent<BaseStats>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Clicked();
        }


        if (Target != null)
        {
            float distToTarget = (Target.transform.position - transform.position).magnitude;
            if (distToTarget < stats.range && AutoCR == null)
            {
                AutoCR = StartCoroutine(AutoCoroutine());
            }
        }


        //moving
        Vector3 displacement = moveToPos - transform.position;

        if (displacement.magnitude > arrivalThreshold && !currentlyAutoing)
        {
            MoveToNewPosition(speed, displacement.normalized);
        }

    }

    void Clicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] targetableHits = Physics.RaycastAll(ray, Mathf.Infinity, targetableLayerMask);
        Debug.Log("Targetable hits length: " +  targetableHits.Length);
        foreach (RaycastHit targetableHit in targetableHits)
        {
            Debug.Log(targetableHit.collider.name);
        }
        if (targetableHits.Length >0)
        {
            if (targetableHits[targetableHits.Length-1].transform.GetComponent<BaseStats>() != null)
            {
                Target = targetableHits[targetableHits.Length - 1].transform.gameObject;
            }
        } else
        {
            Target = null;
        }
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask);
        if(hit.collider != null)
        {
            moveToPos = hit.point;
            Vector3 directionToMouse = moveToPos - transform.position;
            transform.forward = new Vector3(directionToMouse.x, transform.forward.y, directionToMouse.z);
        }
    }

    void MoveToNewPosition(float speed, Vector3 direction)
    {
        transform.position += new Vector3(direction.x, 0, direction.z) * speed * Time.deltaTime;
    }

    IEnumerator AutoCoroutine()
    {
        currentlyAutoing = true;
        autoTime = 0;
        autoSlider.gameObject.SetActive(true);
        while (autoTime < 1 && Target != null)
        {
            autoSlider.value = autoTime / 1;
            autoTime += Time.deltaTime * stats.attackSpeed;

            //face enemy
            Vector3 directionToEnemy = Target.transform.position - transform.position;
            transform.forward = new Vector3(directionToEnemy.x, transform.forward.y, directionToEnemy.z);
            yield return null;
        }
        currentlyAutoing = false;
        AutoCR = null;
        if(Target != null) SpawnAuto();

    }
    void SpawnAuto()
    {
        autoSlider.gameObject.SetActive(false);
        GameObject autoAttackObject = GameObject.Instantiate(autoPrefab);
        AutoAttack autoattack = autoAttackObject.GetComponent<AutoAttack>();
        autoattack.Init(stats.attackSpeed, stats.attackDamage, Target.transform, transform.position, stats.blueMat);
    }
}
