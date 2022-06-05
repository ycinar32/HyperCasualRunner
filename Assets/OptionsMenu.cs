using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider diff;
    public GameObject Boy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDiff()
    {
        Boy.GetComponent<PlayerMovementTP>().diffuciltyConstant = 1 + diff.value;
        Debug.Log(Boy.GetComponent<PlayerMovementTP>().diffuciltyConstant);
    }
}
