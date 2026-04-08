using System.Collections;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    private BaseStats baseStats;
    private float team;
    private MeshRenderer mR;
    private MaterialPropertyBlock mPB;
    public LayerMask enemyLayerMask;
    private void Start()
    {
        StartCoroutine(InitTargetable());
    }

    private IEnumerator InitTargetable()
    {
        yield return null;
        baseStats = GetComponent<BaseStats>();
        team = baseStats.team;
        mR = GetComponent<MeshRenderer>();
        mPB = new MaterialPropertyBlock();
    }

    private void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        if(team == 1)
        {
            mR.GetPropertyBlock(mPB);

            mPB.SetFloat("_mouseIsHovering", 1);

            mR.SetPropertyBlock(mPB);
        }
    }

    private void OnMouseExit()
    {
        if (team == 1)
        {
            mR.GetPropertyBlock(mPB);

            mPB.SetFloat("_mouseIsHovering", 0);

            mR.SetPropertyBlock(mPB);
        }
    }
}
