using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] public Vector3 rotationVector;
    [SerializeField] private float speed;
    [SerializeField] private float spinEffect;
    [SerializeField] private CapsuleCollider capsuleCollider;
    float difConst = 1f;

   void Start()
    {
        difConst = GameObject.FindGameObjectWithTag("Boy").GetComponent<PlayerMovementTP>().diffuciltyConstant;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dondurrr");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Birakkkk");
    }
}
