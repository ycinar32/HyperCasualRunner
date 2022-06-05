using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionControl : MonoBehaviour
{
    public GameObject Oppenent;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name + Oppenent.name);
        if(collision.collider.tag == "HardObstacle")
        {
            Oppenent.GetComponent<AI>().stateMachine.ChangeState(state_Dead.Instance);
            this.transform.position = collision.collider.GetComponent<AI>().initialPos;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + Oppenent.name);
        if (other.tag == "RotatingObstacle" || other.tag == "HardObstacle")
        {
            Oppenent.GetComponent<AI>().stateMachine.ChangeState(state_Dead.Instance);
            this.transform.position = other.GetComponent<AI>().initialPos;
            
        }
    }*/

    private void OnTriggerExit(Collider other)
    {

    }

}
