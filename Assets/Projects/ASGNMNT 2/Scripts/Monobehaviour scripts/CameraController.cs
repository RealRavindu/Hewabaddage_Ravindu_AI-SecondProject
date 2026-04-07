using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour
{
    public KeyCode lockCamKey;
    public KeyCode focusCamKey;
    public float speed;
    public float strengthMod;
    public float edgeThreshold;
    public Transform player;
    public bool camLocked, absoluteCamLocked;
    private Vector3 camLockPosOffset;
    public MeshRenderer safeSpace;
    public LayerMask safeSpaceLayerMask;

    private void Start()
    {
        camLockPosOffset = Camera.main.transform.position;
    }
    private void Update()
    {
        if (camLocked || absoluteCamLocked)
        {
            Camera.main.transform.position = camLockPosOffset + new Vector3(player.position.x, 0, player.position.z);
        }

        //alternating camLocked & absoluteCamLocked bool to lock and unlock camera
        if (Input.GetKeyDown(lockCamKey))
        {
            absoluteCamLocked = !absoluteCamLocked;
        }
        if (Input.GetKeyDown(focusCamKey))
        {
            camLocked = true;
        }
        if (Input.GetKeyUp(focusCamKey))
        {
            camLocked = false;
        }

        if (!absoluteCamLocked)
        {
            //detecting if mouse is on edge of screen or nearby, to move the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, Mathf.Infinity, safeSpaceLayerMask))
            {
                MoveCamera();
            }
        }
        
    }
    void MoveCamera()
    {
        Vector2 totalDisplacement = Input.mousePosition - Camera.main.ViewportToScreenPoint(Vector2.one * 0.5f);
        Debug.Log("total displacement: " + totalDisplacement);
        Vector2 ratioDisplacement = new Vector2(totalDisplacement.x/Screen.height, totalDisplacement.y/Screen.width);
        Debug.Log("ratio displacement: " + ratioDisplacement);
        float strength = ratioDisplacement.magnitude * strengthMod;
        Debug.Log("strength: " + strength);

        Vector2 mousePos = Input.mousePosition;
        float distFromX = (Mathf.Abs(mousePos.x) - Camera.main.ViewportToScreenPoint(Vector2.one * (1-edgeThreshold)).x)/Screen.height;
        float distFromY = (Mathf.Abs(mousePos.y) - Camera.main.ViewportToScreenPoint(Vector2.one * (1 - edgeThreshold)).y)/Screen.width;
        float strengthFromDist = new Vector2(distFromX, distFromY).magnitude;
        Debug.Log("distFromX: " + distFromX + ", " + distFromY + ", " + strengthFromDist);

        Vector3 direction = (Input.mousePosition - Camera.main.ViewportToScreenPoint(Vector2.one * 0.5f)).normalized;
        Transform camTransform = Camera.main.transform;
        camTransform.position += new Vector3(direction.x * speed * strength * Time.deltaTime, 0, direction.y * speed * strength * Time.deltaTime);

    }

}
