using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TimerStopper : MonoBehaviour
{

    public GameObject finishGO;


    void Start()
    {

        //finishGO = GameObject.Find("FinishLine");

    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            finishGO.GetComponent<FinishLine>().startTime = 0;

        }
    }

    void OnTriggerEnter()
    {
        finishGO.GetComponent<FinishLine>().startTime = 0;
    }
}