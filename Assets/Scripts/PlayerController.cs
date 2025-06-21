using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1; // 0 is left, 1 is middle, 2 is right;
    public float laneDistance = 2.5f; //distance between two lanes
    public float jumpForce; // jump direction
    public float gravity = -20;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        controller.Move(direction * Time.fixedDeltaTime);


        //jump bind
        if (controller.isGrounded)
        {
            //direction.y = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                Jump();
            }

        }
        else
        {
            direction.y += gravity * Time.deltaTime;

        }

        //binds for lane input
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        //Calculate where we should be next 
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition,80*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
}
