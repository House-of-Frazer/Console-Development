using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovement movement; //Reference for the PlayerMovement script;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>(); //Setup reference for the PlayerMovement script;
    }
    void BasicMovement() //Controls the inputs for the player's basic movment
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
            movement.Right();
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.Backward();
        }
    }

    void ExtraMovement() //Controls the inputs for the player's advanced movement
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

    void TimeTravel() //Controls the inputs for the player's time travel mechanic
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            movement.TimeTravel();
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
        TimeTravel();
    }
}
