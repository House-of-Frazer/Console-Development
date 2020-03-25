using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateControl;

public class AI : MonoBehaviour {

    //create a State Machine object
    public StateMachine<AI> stateMachine { get; set; }

    public GameObject player; //Object to reference the Player

    public Vector3 startingPos; //The starting point of the cube when the game is started

    public float distanceFromPlayer; //The current distance of the player from the AI Cheese Gobbler
    public float distanceFromStartingLocation; //The current distance from its starting location

    EnemyDamage damageControl; //Reference to Enemy Damage Script

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this); //set stateMachine object
        stateMachine.ChangeState(IdleState.Instance); //set initial state to idle

        player = GameObject.FindGameObjectWithTag("Player"); //Find the player and set it to player

        startingPos = this.transform.position; //Set the starting position to be the current position of the AI

        damageControl = GetComponent<EnemyDamage>(); //Set damage Control to Enemy Damage script
    }

    private void Update()
    {
        //when moving set color to red
        /*if (stateMachine._currentState == MoveState.Instance)
        {
            mat.color = Color.red;
        }*/

        //set Distance variables
        distanceFromPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
        distanceFromStartingLocation = Vector3.Distance(gameObject.transform.position, startingPos);

        //if Player attacks and instance is latched onto player, destroy instance
        if (damageControl.EnemycurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

        //call the update function of the state
        stateMachine.Update();
    }
}
