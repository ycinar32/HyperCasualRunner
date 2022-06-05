using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Run : State<AI>
{
    private static state_Run _instance;
    public GameObject[] rotatingObstacles;

    private state_Run()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Run Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Run();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        _owner.navMesh.enabled = true;
        _owner.navMesh.SetDestination(_owner.Finish.position);
        _owner.animator.SetBool("isMoving", true);
        rotatingObstacles =  GameObject.FindGameObjectsWithTag("RotatingObstacle");
        /*for(int i = 0; i <rotatingObstacles.Length; i++)
        {
            Debug.Log(i.ToString() + rotatingObstacles[i].transform.GetChild(1).gameObject.transform.position);
        }*/
    }

    public override void ExitState(AI _owner)
    {
       // Debug.Log("Exiting state_Wait State");
    }

    public override void UpdateState(AI _owner)
    {
        for (int i = 0; i < rotatingObstacles.Length; i++)
        {
           if(!_owner.feltDown && _owner.canJump && _owner.isGrounded && (Mathf.Abs((_owner.transform.position - rotatingObstacles[i].transform.GetChild(1).gameObject.transform.position).magnitude) < 8f))
            {
                //_owner.stateMachine.ChangeState(state_Jump.Instance);
            }
        }

        if(_owner.transform.position.z > 250f)
        {
            _owner.stateMachine.ChangeState(state_Finished.Instance);
        }
    }
}