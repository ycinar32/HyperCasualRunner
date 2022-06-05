using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Jump : State<AI>
{
    private static state_Jump _instance;

    private state_Jump()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Jump Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Jump();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        _owner.animator.SetTrigger("jumping");
        _owner.navMesh.enabled = false;
        _owner.rb.isKinematic = false;
        float x = 0;
        x = Mathf.Tan(_owner.transform.rotation.y);
        Vector3 jumpDirection = (new Vector3(x, 0f, 1f)*_owner.directionJumpSpeed) + new Vector3(0f, 1f, 0f) * _owner.jumpSpeed;
        _owner.rb.AddForce(jumpDirection);
        _owner.GetComponent<AI>().JumpTimeout();
    }

    public override void ExitState(AI _owner)
    {

    }

    public override void UpdateState(AI _owner)
    {

    }
}