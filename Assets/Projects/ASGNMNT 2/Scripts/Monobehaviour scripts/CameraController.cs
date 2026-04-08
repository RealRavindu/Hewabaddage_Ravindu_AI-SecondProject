using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour
{
    public KeyCode lockCamKey;
    public KeyCode focusCamKey;
    public float speed;
    public Transform player;
    private bool camLocked, absoluteCamLocked;
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
        Vector3 direction = (Input.mousePosition - Camera.main.ViewportToScreenPoint(Vector2.one * 0.5f)).normalized;
        Rigidbody camRB = Camera.main.GetComponent<Rigidbody>();
        camRB.AddForce(new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime, ForceMode.Impulse);

    }

}
