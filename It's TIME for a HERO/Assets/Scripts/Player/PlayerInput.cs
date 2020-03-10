using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementN movement; //Reference for the PlayerMovement script;
    TimeTravel travel; // Referecnce to the TimeTrvael script;

    private void Awake()
    {
        movement = GetComponent<PlayerMovementN>(); //Setup reference for the PlayerMovement script;
        travel = GetComponent<TimeTravel>(); //Setup reference for the PlayerMovement script;
    }
    void BasicMovement() //Controls the inputs for the player's basic movment
    {
        //player can only act if they are not time travelling
        if (TimeTravel.timeTravel == false)
        {
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
        }
    }

    void ExtraMovement() //Controls the inputs for the player's advanced movement
    {
        //player can only act if they are not time travelling
        if (TimeTravel.timeTravel == false)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                movement.RotateLeft();
            }
            if (Input.GetKey(KeyCode.E))
            {
                movement.RotateRight();
            }
            if (Input.GetKeyDown(KeyCode.Space) && movement.PlayerGrounded)
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
            if (Input.GetKeyDown(KeyCode.T))
            {
                TimeTravel.timeTravel = true;
                //movement.TimeTravel();
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
    }
}
