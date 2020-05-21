using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementN movement; //Reference for the PlayerMovement script;
    TimeTravel travel; // Referecnce to the TimeTrvael script;
    bool showDebug;
    public GameObject DebugInfo;

    private void Awake()
    {
        movement = GetComponent<PlayerMovementN>(); //Setup reference for the PlayerMovement script;
        travel = GetComponent<TimeTravel>(); //Setup reference for the PlayerMovement script;
        DebugInfo.SetActive(false);
    }
    void BasicMovement() //Controls the inputs for the player's basic movment
    {
        //player can only act if they are not time travelling
        if (TimeTravel.timeTravel == false)
        { 
            /*
            if (Input.GetKey(KeyCode.W))
            {
                movement.Forward();
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                movement.Left();
            }

            if (Input.GetKey(KeyCode.S))
            {
                movement.Backward();
            }

            if (Input.GetKey(KeyCode.D))
            {
                movement.Right();
            }
            */
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                movement.Forward();
            }

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                movement.Backward();
            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                movement.Left();
            }

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                movement.Right();
            }
        }
    }

    void ExtraMovement() //Controls the inputs for the player's advanced movement
    {
        //player can only act if they are not time travelling
        if (TimeTravel.timeTravel == false)
        {
            if (Input.GetButton("LBumper"))
            {
                movement.RotateLeft();
            }
            if (Input.GetButton("RBumper"))
            {
                movement.RotateRight();
            }
            if (Input.GetButton("Jump") && movement.PlayerGrounded)
            {
                StartCoroutine(movement.Jumping());
            }
        }
    }

    void TimeTravelling() //Controls the inputs for the player's time travel mechanic
    {
        //player can only act if they are not time travelling
        if (TimeTravel.timeTravel == false && movement.PlayerGrounded)
        {
            if (Input.GetButton("TimeTravel"))
            {
                TimeTravel.timeTravel = true;
                //movement.TimeTravel();
            }
        }
    }

    void showDebugInfo()
    {
        if (Input.GetButtonDown("Debug"))
        {
            if (showDebug == false)
            {
                showDebug = true;
                DebugInfo.SetActive(true); ;
            }
            else
            {
                showDebug = false;
                DebugInfo.SetActive(false);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BasicMovement();
        ExtraMovement();
        TimeTravelling();
        showDebugInfo();
    }
}

