using UnityEngine;

public class HomeOwner : MonoBehaviour
{ 
    [SerializeField] Vector3 direction;
    Rigidbody rb;
    public float speed;
    public KeyCode dashKey;
    public float dashSpeed, dashCooldown;
    bool dashAvailable = true;
    bool justPressedDash;
    float timeSinceDash;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));

        if (dashAvailable)
        {
            if(Input.GetKeyDown(dashKey) && direction != Vector3.zero)
            {
                Debug.Log("Dash!");
                justPressedDash = true;
                dashAvailable = false;
            }
            
        } else
        {
            timeSinceDash += Time.deltaTime;
            Debug.Log("cooldown timer: " +timeSinceDash);
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

        if (justPressedDash)
        {

            rb.AddForce(direction * dashSpeed * Time.deltaTime, ForceMode.Impulse);
            justPressedDash = false;
        }

        
    }
}
