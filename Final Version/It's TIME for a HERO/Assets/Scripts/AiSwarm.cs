using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSwarm : MonoBehaviour {

    //This script is for CheeseGobblers on the Moon!

    //The position of the player
    public GameObject player;

    //Latch on stuff
    //public Transform other; //Transform position of the player
    public float speed; //The Speed to control how fast the Cheese Gobbler Latches on to the player
    float ActiveState; // 
    bool latched; //Bool to determine if entity is currently latched onto the player
    bool attacking = false; //Bool to determine if entity is in attacking mode
    float randX; //Float to randomize X latching on position
    float randZ; //Float to randomize Z latching on position
    float randY; //Float to aid in randomizing Y latching on position
    float Yrand; //Float to hold random Y latching on position

    float damageTimer = 0.8f;

    //Group Stuff
    //public Transform Leader = null; //set the leader for this instance

    //The current distance of the player from the AI Cheese Gobbler
    public float distanceFromPlayer;
    //The current distance from its starting location
    public float distanceFromStartingLocation;
    //The current distance from the random idlePosition
    public float distanceFromIdlePosition;

    //Rotation speed of the ai when turning to face direction
    private float rotationspeed = 2f;
    //Movement speed of the cube
    private float movementSpeed = 2f;


    //The starting point of the cube when the game is started
    //Holds the starting position values mentioned in the start method
    public Vector3 startingPos;

    //Random angle for the idleMovement method, cube moves to a random point
    //but uses the starting position as a base, then adds random values to x and z
    public Vector3 randomAngle;

    //Bool used in the idleMovement method where the cube only moves if the bool is true
    public bool switcher;

    //Timer to be used within the idleMovement method for changing the switcher bool
    public float timer;


    // Use this for initialization
    void Start()
    {
        //Find the player and set it to player
        player = GameObject.FindGameObjectWithTag("Player");

        //Set the starting position to be the current position of the AI
        startingPos = this.transform.position;

        //Sets a random starting timer for the AI to add variety between groups of AI
        timer = Random.Range(0, 4);

        //Set the switcher to false so the cube doesnt move straight away.
        switcher = false;

        randX = Random.Range(-0.5f, 0.5f); //latch on random x
        randZ = Random.Range(-0.4f, 0.4f); //latch on random z
        randY = Random.Range(0, 2); //Choose which side of the player to grab onto

        //set the Cheese Gobblers random Y to one of two choices (either side of the player)
        if (randY == 0)
            Yrand = 1.9f;
        if (randY == 1)
            Yrand = -1.9f;
    }

    // Update is called once per frame
    void Update()
    {
        ////////// Controls what state the AI is currently in depending on the distnace the AI is from the player

        //Calculate distance between two objects using the Vector3.distance function
        //Useful for creating an if condition based on the distance from one object to another
        distanceFromPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
        distanceFromStartingLocation = Vector3.Distance(gameObject.transform.position, startingPos);
        distanceFromIdlePosition = Vector3.Distance(gameObject.transform.position, randomAngle);

        //For if the player is within the target distance, make the Cheese Gobbler AI run towards the player
        //otherwise idle
        if (attacking == false)
        {
            if (distanceFromPlayer < 10)
            {
                //Call runToState
                runToState();
            }
            else
            {
                //Run the idle state as default
                idleState();
            }
        }

        //if ActiveState is true, call the Carry Method
        if (ActiveState == 1)
        {
            Carry();
        }

        //Destroy the enemy

        //if Player attacks and instance is latched onto player, destroy instance
        /*if (player is attacking == true)
        {
                //Destroy(gameObject);

        }*/

    }

    //////Methods for the different states the AI is in. These methods are called within the 
    //////update depending on the conditions of the AI

    //Idle state
    //This is for when the player isn't nearby
    void idleState()
    {
        //If the AI is so far away from the starting location AND is far away from the player
        if (attacking == false)
        {
            if (distanceFromStartingLocation > 5 && distanceFromPlayer >= 10)
            {
                //Run back to the starting location
                runBack();
            }
            //If the AI is back at the starting location
            else
            {
                //call idleMovement method
                idleMovement();
            }
        }
    }

    //RunningTo state
    //for when the player is within range
    void runToState()
    {

        if (attacking == false)
        {
            //Vector3 variable on the direction of which to face
            Vector3 runToDirection;
            //Quaternion to hold the angle of what direction to look in to look at the runToRotation
            Quaternion runToRotation;

            //Move the AI forward
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

            //Set the direction based on the player's position and the AI's current position
            runToDirection = player.transform.position - transform.position;
            //Set the quaternion rotation to look at the Vector3 direction
            runToRotation = Quaternion.LookRotation(runToDirection);
            //Rotate the AI towards the runToRotation smoothly based on the rotaion speed
            transform.rotation = Quaternion.Lerp(transform.rotation, runToRotation, rotationspeed * Time.deltaTime);

            if (distanceFromPlayer <= 2)
            {
                //Run back to the starting location
                attacking = true;
                attackState();
            }
        }

    }

    //When Cheese Gobbler collides with the player, set latch on to true
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            latched = true;
        }
    }

    //Method for controlling the latch on state of the Cheese Gobbler AI
    void Carry()
    {
        float step = speed * Time.deltaTime; //set speed to latch onto the player.

        //if not latched on, try to latch on
        if (latched == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        //if latched on, activate latching on controls
        
    }

    //Attacking state
    //The Cheese Gobbler will latch onto the player.
    void attackState()
    {
        Debug.Log("Attack"); //Debug
        ActiveState = 1;
        if (ActiveState == 1)
        {
            Carry();
        }
    }

    //RunningBack state
    //for when the player isnt within range
    void runBack()
    {
        if (attacking == false)
        {
            //Vector3 variable on the direction of which to face
            Vector3 runBackDirection;
            //Quaternion to hold the angle of what direction to look in to look at the runBackRotation
            Quaternion runBackRotation;

            //Move the AI forward
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

            //Set the direction based on the AI's starting position and the AI's current position
            runBackDirection = startingPos - transform.position;
            //Set the quaternion rotation to look at the Vector3 direction
            runBackRotation = Quaternion.LookRotation(runBackDirection);
            //Rotate the AI towards the runBackRotation smoothly based on the rotaion speed
            transform.rotation = Quaternion.Lerp(transform.rotation, runBackRotation, rotationspeed * Time.deltaTime);
        }
    }


    //IdleMovement state
    //to add random movement to the AI when it is stationary at its starting location
    void idleMovement()
    {
        if (attacking == false)
        {
            //Moving the AI to look at the starting point + a random andle between two values
            //that way theres variety in the idle movement

            //Vector3 variable on the direction of which to face
            Vector3 idleDirection;
            //Quaternion to hold the angle of what direction to look in
            Quaternion idleRotation;

            //Set the direction based on the position of where to go (direction), based on the position from the randomAngle, and the AI's current position
            idleDirection = randomAngle - transform.position;
            //Quaternion to hold the angle of what direction to look in to look at the idleDirection
            idleRotation = Quaternion.LookRotation(idleDirection);


            //Count the timer variable down by delta time
            timer -= Time.deltaTime;

            //When the timer reaches 0
            //Switch the bool
            //& reset timer
            if (timer < 0)
            {
                //Provides a random value for the AI to move to. Based on the starting position, it adds a random range to the X and Z components
                randomAngle = new Vector3(startingPos.x + Random.Range(-5, 5), startingPos.y, startingPos.z + Random.Range(-5, 5));

                //Toggles state of the switcher, changes to what it currently isnt. (True to false, false to true)
                switcher = !switcher;

                //Adds time abck to the timer to start again
                timer += Random.Range(2, 4);
            }
            //Changes between a walking state and a standing state
            //Only moves the AI if the bool is true
            //Otherwise the AI will not move (wait)

            //IF the bool is true AND the distance from the idlePosition is greater than 0.8
            //This is so it dont breakdance at the point.
            if (switcher == true && distanceFromIdlePosition >= 0.8f)
            {
                //Rotate towards the direction of the idleRotation position by rotationspeed
                transform.rotation = Quaternion.Lerp(transform.rotation, idleRotation, rotationspeed * Time.deltaTime);

                //Move towards that position
                transform.Translate(Vector3.forward * (movementSpeed / 2) * Time.deltaTime);
            }
            //Otherwise, idle
        }
    }
}
