using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutMovement : MonoBehaviour
{
    [SerializeField] private Vector3 desiredPos;
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private float speed;
    [SerializeField] private bool returnWay = false;
    [SerializeField] private int yVector;
    private float difConst = 1f;

    private void Awake()
    {
        initialPos = transform.position;
        desiredPos.x = initialPos.x;
        desiredPos.z = initialPos.z;
        if (transform.position.y < desiredPos.y)
        {
            yVector = 1;
        }
        else
        {
            yVector = -1;
        }
    }
    private void Start()
    {
        difConst = GameObject.FindGameObjectWithTag("Boy").GetComponent<PlayerMovementTP>().diffuciltyConstant;
    }
    private void Update()
    { 
        if ((Mathf.Abs((transform.position.y - desiredPos.y)) <= 0.1f) && !returnWay)
        {
            yVector *= (-1);
            returnWay = true;
        }
        else if((Mathf.Abs((transform.position.y - initialPos.y)) <= 0.1f) && returnWay)
        {
            yVector *= (-1);
            returnWay = false;
        }

        transform.Translate(new Vector3(0f, yVector, 0f) * speed * Time.deltaTime, Space.World);
    }

    private void LateUpdate()
    {
        if (transform.position.y > initialPos.y)
        {
            transform.position = initialPos;
            returnWay = true;
        }
        if (transform.position.y < desiredPos.y)
        {
            transform.position = desiredPos;
            returnWay = false;
        }
    }
}
