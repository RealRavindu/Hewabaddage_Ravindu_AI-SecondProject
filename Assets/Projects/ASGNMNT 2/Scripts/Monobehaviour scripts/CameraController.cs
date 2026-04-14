using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour
{
    public KeyCode lockCamKey;
    public KeyCode focusCamKey;
    public float speed;
    private Transform player;
    private bool camLocked, absoluteCamLocked;
    private Vector3 camLockPosOffset;
    public float edgeThreshold;
    public float scrollAmount;
    public float minScroll, maxScroll;
    private void Start()
    {
        camLockPosOffset = Camera.main.transform.position;
        player = GetComponent<Transform>();
    }
    private void Update()
    {
        if (camLocked || absoluteCamLocked)
        {
            Camera.main.transform.position = camLockPosOffset + new Vector3(player.position.x, scrollAmount, player.position.z);
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

        //camera zoom in
        scrollAmount -= Input.mouseScrollDelta.y;
        scrollAmount = Mathf.Clamp(scrollAmount, minScroll, maxScroll);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, scrollAmount, Camera.main.transform.position.z);


        if (!absoluteCamLocked)
        {
            //detecting if mouse is on edge of screen or nearby, to move the camera
            Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (mousePos.x < edgeThreshold || mousePos.x > 1 - edgeThreshold || mousePos.y < edgeThreshold || mousePos.y > 1 - edgeThreshold)
            {
                MoveCamera();
            }
        }
        
    }
    void MoveCamera()
    {
        //applying a force in the direction the mouse is FROM the center of the screen so that it simulates the acceleration and deceleration that league's camera has.
        Vector3 direction = (Input.mousePosition - Camera.main.ViewportToScreenPoint(Vector2.one * 0.5f)).normalized;
        Rigidbody camRB = Camera.main.GetComponent<Rigidbody>();
        camRB.AddForce(new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime, ForceMode.Impulse);
    }

    

}
