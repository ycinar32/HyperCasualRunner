using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundForOpponent : MonoBehaviour
{
    public GameObject Oppenent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Platform")
        {
            Oppenent.GetComponent<AI>().isGrounded = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Platform")
        {
            Oppenent.GetComponent<AI>().isGrounded = false;
        }

    }
}
