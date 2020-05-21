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

    EnemyDamage damageControl; //Reference to Enemy Damage Scrip

    public GameObject rangedAttack;

    Renderer rend;
    float _timer = 0;


    private void Start()
    {
        stateMachine = new StateMachine<AI>(this); //set stateMachine object
        stateMachine.ChangeState(IdleState.Instance); //set initial state to idle

        player = GameObject.FindGameObjectWithTag("Player"); //Find the player and set it to player
        rend = GetComponent<Renderer>();

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
            //Disslove the enemy away by affecting the shader applied to the enemy
            _timer += Time.deltaTime / 2;
            Debug.Log(_timer);
            float dissolveAmount = _timer;
            //Set value to renderer to control dissolve amount
            rend.material.SetFloat("_Amount", dissolveAmount);
            if (_timer > 1)
            {
                //Once the enemy has dissolved, destroy the gameobject
                Destroy(this.gameObject);
            }
        }

        //call the update function of the state
        stateMachine.Update();
    }
}
