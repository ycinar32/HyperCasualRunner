using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Finished : State<AI>
{
    private static state_Finished _instance;

    private state_Finished()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Finished Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Finished();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        _owner.finished = true;
    }

    public override void ExitState(AI _owner)
    {
       // Debug.Log("Exiting state_Wait State");
    }

    public override void UpdateState(AI _owner)
    {
		
    }
}