using UnityEngine;
using StateControl;

public class RunBackState : State<AI>
{
    //create a single instance of the state
    private static RunBackState _instance;

    private float rotationspeed = 2f; //Rotation speed of the ai when turning to face direction
    private float movementSpeed = 2f; //Movement speed of the cube

    //constructor
    private RunBackState()
    {
        //if state already exists then return
        if (_instance != null)
        {
            return;
        }
        //if not set instance to this
        _instance = this;
    }

    public static RunBackState Instance
    {
        get
        {
            //if state doens't exist, create state
            if (_instance == null)
            {
                new RunBackState();
            }
            return _instance;
        }
    }

    //Enter State function
    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering Run Back State");
    }

    //Exit State Function
    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting Run Back State");
    }

    //Function for what happens in this state
    public override void UpdateState(AI _owner)
    {
        //_owner.stateMachine.ChangeState(IdleState.Instance); //switch to Idle state

        //Vector3 variable on the direction of which to face
        Vector3 runBackDirection;
        //Quaternion to hold the angle of what direction to look in to look at the runBackRotation
        Quaternion runBackRotation;

        //Move the AI forward
        _owner.gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        //Set the direction based on the AI's starting position and the AI's current position
        runBackDirection = _owner.startingPos - _owner.gameObject.transform.position;
        //Set the quaternion rotation to look at the Vector3 direction
        runBackRotation = Quaternion.LookRotation(runBackDirection);
        //Rotate the AI towards the runBackRotation smoothly based on the rotaion speed
        _owner.gameObject.transform.rotation = Quaternion.Lerp(_owner.gameObject.transform.rotation, runBackRotation, rotationspeed * Time.deltaTime);

        if (_owner.distanceFromStartingLocation < 5)
        {
            _owner.stateMachine.ChangeState(IdleState.Instance); //switch to Idle state
        }

        if (_owner.distanceFromPlayer < 10)
        {
            //Call runToState
            _owner.stateMachine.ChangeState(RunToState.Instance); //switch to Move state
        }
    }
}
