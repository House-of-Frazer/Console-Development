namespace StateControl
{

    public class StateMachine<T>
    {
        public State<T> _currentState { get; private set; } //the current state
        public T owner; //The Object that will use this State Machine

        //constructor
        public StateMachine(T _o)
        {
            owner = _o;
            _currentState = null; //no states set at start
        }

        //function for changing state
        public void ChangeState(State<T> _newState)
        {
            //if there is a current state, exit that state
            if (_currentState != null)
                _currentState.ExitState(owner);

            _currentState = _newState; //set current state to the new state
            _currentState.EnterState(owner); //call enter function for new state
        }

        public void Update()
        {
            if (_currentState != null)
                _currentState.UpdateState(owner);
        }
    }

    public abstract class State<T>
    {
        public abstract void EnterState(T _owner); 
        public abstract void ExitState(T _owner); 
        public abstract void UpdateState(T _owner);
    }
}
