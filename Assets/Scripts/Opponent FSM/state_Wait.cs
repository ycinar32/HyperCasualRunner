using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Wait : State<AI>
{
    private static state_Wait _instance;

    private state_Wait()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Wait Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Wait();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
       // Debug.Log("Entering state_Wait State");
    }

    public override void ExitState(AI _owner)
    {
       // Debug.Log("Exiting state_Wait State");
    }

    public override void UpdateState(AI _owner)
    {
        _owner.stateMachine.ChangeState(state_Run.Instance);
    }
}