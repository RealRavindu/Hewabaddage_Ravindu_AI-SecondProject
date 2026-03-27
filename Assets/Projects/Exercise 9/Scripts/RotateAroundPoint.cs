using ParadoxNotion.Design;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public Vector3 point;
    public float radius, speed;
    [SliderField(0, 360)] public float offset;
    public bool rotateX, rotateY, rotateZ;
    private float angle;

    private void Start()
    {
        angle = offset*Mathf.Deg2Rad;
    }
    // Update is called once per frame
    void Update()
    {
        RotateAroundPointFunction();
    }

    void RotateAroundPointFunction()
    {
        angle += Time.deltaTime * speed;

        Vector3 newPosition = new Vector3((rotateX ? Mathf.Cos(angle%(Mathf.PI*2)) * radius : 0) + point.x, 
            (rotateY ? Mathf.Sin(angle % (Mathf.PI * 2)) * radius: 0 )+ point.y, 
            (rotateZ ? Mathf.Sin(angle % (Mathf.PI * 2)) * radius : 0 ) + point.z);

        transform.position = newPosition;
    }
}
