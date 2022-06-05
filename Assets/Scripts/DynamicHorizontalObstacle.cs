using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicHorizontalObstacle : MonoBehaviour
{
    public Vector3 initialPos;
    public float desiredPos_x;
    public float desiredPos_y;
    public float desiredPos_z;
    public int xVector = 0;
    public int yVector = 0;
    public int zVector = 0;
    public float speed = 3f;
    public bool returnWay = false;
    Vector3 desiredPos;
    private void Awake()
    {

        initialPos = transform.position;

        desiredPos.x = desiredPos_x;
        desiredPos.y = initialPos.y;
        desiredPos.z = initialPos.z;

        if ((transform.position.x - desiredPos_x) < 0f)
        {
            xVector = +1;
        }
        else
        {
            xVector = -1;
        }
    }

    void Start()
    {
        float difConst = GameObject.FindGameObjectWithTag("Boy").GetComponent<PlayerMovementTP>().diffuciltyConstant;
    }
    void Update()
    {
        if(((transform.position - desiredPos).magnitude < 0.3f) && !returnWay)
        {
            xVector = xVector * (-1);
            returnWay = true;
        }
        if(returnWay && ((transform.position - initialPos).magnitude < 0.3f))
        {
            xVector = xVector * (-1);
            returnWay = false;
        }
        Vector3 movement = new Vector3(xVector, 0f, 0f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
