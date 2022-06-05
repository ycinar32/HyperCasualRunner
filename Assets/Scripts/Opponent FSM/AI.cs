using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StateStuff;
using System.Linq;

    public class AI : MonoBehaviour
    {
        public GameObject Opponent;
        public GameObject Boy;
        public StateMachine<AI> stateMachine { get; set; }
		public NavMeshAgent navMesh;
		public Animator animator;
        public Rigidbody rb;
        public float jumpSpeed;
        public float directionJumpSpeed;
        public float gravity;
        public bool isGrounded ;
        public bool canJump = true;
        public bool feltDown = false;
        public Vector3 initialPos;
        public Transform Finish;
        public bool finished = false;


    private void Awake()
    {
        isGrounded = true;
        initialPos = transform.position;
    }
    private void Start()
        {
            stateMachine = new StateMachine<AI>(this);
            stateMachine.ChangeState(state_Wait.Instance);
			navMesh = this.GetComponent<NavMeshAgent>();
			animator = this.GetComponent<Animator>();
        }

        private void Update()
        {
            stateMachine.Update();
            if (finished)
            {
                this.navMesh.enabled = false;
                this.rb.isKinematic = false;
                this.rb.MovePosition(new Vector3(0f, 0f, 270f));
            }
            rb.AddForce(Vector3.down * gravity);
            Debug.Log(this.stateMachine.currentState);
            //Debug.Log(stateMachine.currentState);
    }


    public void JumpTimeout()
    {
        StartCoroutine(TimeoutCorouitine());
    }
    private IEnumerator TimeoutCorouitine()
    {
        yield return new WaitForSeconds(1.5f);
        rb.isKinematic = true;
        navMesh.enabled = true;
        navMesh.SetDestination(Finish.position);
        animator.SetBool("isMoving", true);
        canJump = true;
    }

    public void ReturnHome()
    {
        StartCoroutine(ReturnHomeCorouitine());
    }
    private IEnumerator ReturnHomeCorouitine()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        feltDown = false;
        rb.MovePosition(initialPos);
    }


}
