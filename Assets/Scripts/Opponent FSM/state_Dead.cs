using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Dead : State<AI>
{
    private static state_Dead _instance;

    private state_Dead()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Dead Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Dead();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        Debug.Log(_owner.name + "Dead");
        _owner.navMesh.enabled = false;
        _owner.rb.MovePosition(_owner.initialPos);
        _owner.stateMachine.ChangeState(state_Wait.Instance);
    }

    public override void ExitState(AI _owner)
    {
        _owner.navMesh.enabled = true;
    }

    public override void UpdateState(AI _owner)
    {

    }
}