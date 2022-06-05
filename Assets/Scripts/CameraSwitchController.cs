using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitchController : MonoBehaviour
{
    public bool wallCam = false;
    public Animator animatorController;
    public Canvas RunnerUI;
    public Canvas WallUI;
    public Text TimeText;
    GameObject player;
    public GameObject[] Opponents;

    private int aheadOpponentsCount;
    private int finishedOpponentsCount;
    private int rank;

    public Text RankText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Boy");
        Opponents = GameObject.FindGameObjectsWithTag("Opponent");
    }
    void Update()
    {
        
        if (wallCam)
        {
            animatorController.Play("WallCam");
        }


    }

    private void FixedUpdate()
    {
        if (player.GetComponent<PlayerMovementTP>().gameisStarted)
        {
            TimeText.text = (Time.time - player.GetComponent<PlayerMovementTP>().initialTime).ToString().Split(","[0])[0] + "''"; 
        }

        for (int i = 0; i < Opponents.Length; i++)
        {
            if (player.transform.position.z > Opponents[i].transform.GetChild(1).gameObject.transform.position.z)
            {
                aheadOpponentsCount += 1;
            }
        }

        rank = 11 - aheadOpponentsCount;
        RankText.text = "Rank: " + rank.ToString();
        aheadOpponentsCount = 0;
        finishedOpponentsCount = 0;
    }
}
