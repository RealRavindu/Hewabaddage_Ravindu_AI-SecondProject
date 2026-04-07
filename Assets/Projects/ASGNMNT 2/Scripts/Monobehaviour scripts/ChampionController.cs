using UnityEngine;
using UnityEngine.InputSystem;

public class ChampionController : MonoBehaviour
{
    public float speed;
    public LayerMask groundLayerMask;
    private Vector3 moveToPos;
    private Rigidbody rb;
    public float arrivalThreshold;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveToPos = SetNewPosition();
        }

        Vector3 displacement = moveToPos - transform.position;

        if(displacement.magnitude > arrivalThreshold)
        {
            MoveToNewPosition(speed, displacement.normalized);
        }

    }

    Vector3 SetNewPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask);
        return hit.point;
    }

    void MoveToNewPosition(float speed, Vector3 direction)
    {
        transform.forward = new Vector3(direction.x, transform.forward.y, direction.z);
        transform.position += new Vector3(direction.x, 0, direction.z) * speed * Time.deltaTime;
    }
}
