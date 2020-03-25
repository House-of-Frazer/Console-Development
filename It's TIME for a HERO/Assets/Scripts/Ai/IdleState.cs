using UnityEngine;
using StateControl;

public class IdleState : State<AI>
{
    //Create a static instance of this state
    private static IdleState _instance;

    public GameObject player; //Object to reference the Player

    public Vector3 randomAngle; //Random angle for the idleMovement method, cube moves to a random point
    public float timer; //Timer to be used within the idleMovement method for changing the switcher bool
    public bool switcher; //Bool used in the idleMovement method where the cube only moves if the bool is true

    public float distanceFromIdlePosition;     //The current distance from the random idlePosition

    private float rotationspeed = 2f; //Rotation speed of the ai when turning to face direction
    private float movementSpeed = 2f; //Movement speed of the cube


    //constructor
    private IdleState()
    {
        //if state already exists then return
        if(_instance != null)
        {
            return;
        }
        //if not set instance to this
        _instance = this;
    }

    public static IdleState Instance
    {
        get
        {
            //if state doens't exist, create state
            if (_instance == null)
            {
                new IdleState();
            }
            return _instance;
        }
    }

    //Enter State function
    public override void EnterState(AI _owner)
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Find the player and set it to player

        timer = Random.Range(0, 4); //Sets a random starting timer for the AI to add variety between groups of AI
        switcher = false; //Set the switcher to false so the cube doesnt move straight away.
    }

    //Exit State Function
    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting Idle State");
    }

    //Function for what happens in this state
    public override void UpdateState(AI _owner)
    {
        //_owner.stateMachine.ChangeState(MoveState.Instance); //switch to Move state
        //Moving the AI to look at the starting point + a random andle between two values
        //that way theres variety in the idle movement

        //Calculate distance between two objects using the Vector3.distance function
        //Useful for creating an if condition based on the distance from one object to another
        _owner.distanceFromStartingLocation = Vector3.Distance(_owner.gameObject.transform.position, _owner.startingPos);
        distanceFromIdlePosition = Vector3.Distance(_owner.gameObject.transform.position, randomAngle);

        //Vector3 variable on the direction of which to face
        Vector3 idleDirection;
        //Quaternion to hold the angle of what direction to look in
        Quaternion idleRotation;

        //Set the direction based on the position of where to go (direction), based on the position from the randomAngle, and the AI's current position
        idleDirection = randomAngle - _owner.gameObject.transform.position;
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
                randomAngle = new Vector3(_owner.startingPos.x + Random.Range(-5, 5), _owner.startingPos.y, _owner.startingPos.z + Random.Range(-5, 5));

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
                _owner.gameObject.transform.rotation = Quaternion.Lerp(_owner.gameObject.transform.rotation, idleRotation, rotationspeed * Time.deltaTime);

                //Move towards that position
                _owner.gameObject.transform.Translate(Vector3.forward * (movementSpeed / 2) * Time.deltaTime);
            }
        //Otherwise, idle

        if (_owner.distanceFromPlayer < 10)
        {
            //Call runToState
            _owner.stateMachine.ChangeState(RunToState.Instance); //switch to Move state
        }
    }
}
