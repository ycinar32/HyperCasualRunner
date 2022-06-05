using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float speed;
    private float difConst = 1f;


    void Start()
    {
        difConst = GameObject.FindGameObjectWithTag("Boy").GetComponent<PlayerMovementTP>().diffuciltyConstant;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * speed * Time.deltaTime * difConst);
    }
}
