using UnityEngine;
using StateControl;

public class MoveState : State<AI>
{
    //create a single instance of the state
    private static MoveState _instance;

    //constructor
    private MoveState()
    {
        //if state already exists then return
        if (_instance != null)
        {
            return;
        }

        //if not set instance to this
        _instance = this;
    }

    public static MoveState Instance
    {
        get
        {
            //if state doens't exist, create state
            if (_instance == null)
            {
                new MoveState();
            }

            return _instance;
        }
    }

    //Enter State function
    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering Move State");
    }

    //Exit State Function
    public override void ExitState(AI _owner)
    {
        Debug.Log("Exiting Move State");
    }

    //Function for what happens in this state
    public override void UpdateState(AI _owner)
    {
        //_owner.stateMachine.ChangeState(IdleState.Instance); //switch to Idle state
    }
}
