using System.Collections;
using UnityEngine;

public class HurtAnimator : MonoBehaviour
{
    SkinnedMeshRenderer SKR;
    MeshRenderer MR;
    Material originalMat;
    public Material hurtMat;
    public float hurtTime;
    private Coroutine hurtCR;

    private void Start()
    {
        SKR = GetComponent<SkinnedMeshRenderer>();
        MR = GetComponent<MeshRenderer>();
        if (SKR != null) originalMat = SKR.material;
        else originalMat = MR.material;

    }

    public void StartHurtCoroutine()
    {
        if(hurtCR != null)
        {
            StopCoroutine(hurtCR);
        }
        hurtCR = StartCoroutine(hurtAnimation());
    }
    private IEnumerator hurtAnimation()
    {
        if (SKR != null) {
            SKR.material = hurtMat;
            yield return new WaitForSeconds(hurtTime);
            SKR.material = originalMat;
        } else
        {
            MR.material = hurtMat;
            yield return new WaitForSeconds(hurtTime);
            MR.material = originalMat;
        }
        hurtCR = null;
    }


}
