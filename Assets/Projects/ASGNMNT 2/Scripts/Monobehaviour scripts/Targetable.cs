using System.Collections;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    private BaseStats baseStats;
    private float team;
    private MeshRenderer mR;
    private SkinnedMeshRenderer sMR;
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
        if(baseStats == null) baseStats = transform.parent.GetComponent<BaseStats>();
        team = baseStats.team;
        mR = GetComponent<MeshRenderer>();
        sMR = GetComponent<SkinnedMeshRenderer>();
        mPB = new MaterialPropertyBlock();
    }

    private void OnMouseEnter()
    {
        if(team == 1)
        {
            if(mR != null)
            {
                mR.GetPropertyBlock(mPB);

                mPB.SetFloat("_mouseIsHovering", 1);

                mR.SetPropertyBlock(mPB);
            } else
            {
                sMR.GetPropertyBlock(mPB);

                mPB.SetFloat("_mouseIsHovering", 1);

                sMR.SetPropertyBlock(mPB);
            }
            
        }
    }

    private void OnMouseExit()
    {
        if (team == 1)
        {
            if (mR != null)
            {
                mR.GetPropertyBlock(mPB);

                mPB.SetFloat("_mouseIsHovering", 0);

                mR.SetPropertyBlock(mPB);
            }
            else
            {
                sMR.GetPropertyBlock(mPB);

                mPB.SetFloat("_mouseIsHovering", 0);

                sMR.SetPropertyBlock(mPB);
            }
        }
    }
}
