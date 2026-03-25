using UnityEngine;

public class HomeOwner : MonoBehaviour
{ 
    [SerializeField] Vector2 direction;
    Rigidbody rb;
    public float speed;
    public KeyCode dashKey;
    public float dashSpeed, dashCooldown;
    bool dashAvailable;
    float timeSinceDash;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("horizontal"), Input.GetAxisRaw("vertical"));

        if (dashAvailable)
        {
            if(Input.GetKeyDown(dashKey) && direction != Vector2.zero)
            {
                Debug.Log("Dash!");
                rb.AddForce(direction * dashSpeed * Time.deltaTime, ForceMode.Impulse);
                dashAvailable = false;
            }
            
        } else
        {
            timeSinceDash += Time.deltaTime;
            Debug.Log(timeSinceDash);
            if(timeSinceDash > dashCooldown)
            {
                timeSinceDash = 0;
                dashAvailable = true;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction*speed*Time.deltaTime, ForceMode.Impulse);
    }
}
