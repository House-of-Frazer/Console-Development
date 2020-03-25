using UnityEngine;
using StateControl;

public class RunToState : State<AI>
{
    //create a single instance of the state
    private static RunToState _instance;

    public GameObject player; //Object to reference the Player

    private float rotationspeed = 2f; //Rotation speed of the ai when turning to face direction
    private float movementSpeed = 2f; //Movement speed of the cube

    //constructor
    private RunToState()
    {
        //if state already exists then return
        if (_instance != null)
        {
            return;
        }
        //if not set instance to this
        _instance = this;
    }

    public static RunToState Instance
    {
        get
        {
            //if state doens't exist, create state
            if (_instance == null)
            {
                new RunToState();
            }
            return _instance;
        }
    }

    //Enter State function
    public override void EnterState(AI _owner)
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Find the player and set it to player
    }

    //Exit State Function
    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting Run To State");
    }

    //Function for what happens in this state
    public override void UpdateState(AI _owner)
    {
        //_owner.stateMachine.ChangeState(IdleState.Instance); //switch to Idle state

        //Vector3 variable on the direction of which to face
        Vector3 runToDirection;
        //Quaternion to hold the angle of what direction to look in to look at the runToRotation
        Quaternion runToRotation;

        //Move the AI forward
        _owner.gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        //Set the direction based on the player's position and the AI's current position
        runToDirection = player.transform.position - _owner.gameObject.transform.position;
        //Set the quaternion rotation to look at the Vector3 direction
        runToRotation = Quaternion.LookRotation(runToDirection);
        //Rotate the AI towards the runToRotation smoothly based on the rotaion speed
        _owner.gameObject.transform.rotation = Quaternion.Lerp(_owner.gameObject.transform.rotation, runToRotation, rotationspeed * Time.deltaTime);

        if (_owner.distanceFromPlayer > 10)
        {
            //Call runToState
            _owner.stateMachine.ChangeState(RunBackState.Instance); //switch to Idle state
        }

        /*if (distanceFromPlayer <= 2)
        {
            //Run back to the starting location
            attacking = true;
            attackState();
        }*/
    }
}