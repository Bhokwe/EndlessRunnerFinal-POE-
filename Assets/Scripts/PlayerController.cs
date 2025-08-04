using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1; // 0 is left, 1 is middle, 2 is right;
    public float laneDistance = 2.5f; //distance between two lanes
    public float jumpForce; // jump direction
    public float gravity = -20;
    public float maxSpeed;
    public bool isAlive = true; //check player state bool
    public GameObject GameOverPanel; //for isAlive method - To call/invoke panel from UI scene 
    //private bool activePanel = false;//setting default state for panel, as it should be, in the project - should show panel when true
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        //Increase speed
        if(forwardSpeed<maxSpeed)
        forwardSpeed += 0.08f * Time.deltaTime;


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

    //void IsAlive()
    //{
    //    if (isAlive) //check bool - Is player alive?
    //    {
    //        Update();
    //    }
        
    //    if (!isAlive)
    //    {
    //        isAlive = false;
    //        Time.timeScale = 0;//stop game

    //        //Call/invoke death panel below

    //        gameEndPanel = GameObject.Find("gameEnd"); //intended to find asset with corresponding name

    //        if( gameEndPanel != null)//if game object is found.
    //        {
    //            Debug.Log("Found gameEnd panel!");//check
    //            activePanel = true;//activate/show panel
    //        }
    //    }
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;//conditional bool change - changing PlayerManager bool default 
            FindObjectOfType<AudioManager>().PlaySound("Death");
        }
    }
}
