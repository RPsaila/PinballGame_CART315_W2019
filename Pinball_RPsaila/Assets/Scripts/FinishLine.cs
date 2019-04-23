using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public float startTime;
    private float elapsedTime;


    void Awake()
    {
        startTime = 0;
    }


    void Update()
    {


        if (startTime > 0)
        {
            elapsedTime = Time.time - startTime;
        }

    }


    void OnTriggerEnter()
    {
        startTime = Time.time;
    }


    void OnTriggerExit()
    {
        startTime = 0;
    }


    void OnGUI()
    {
        GUI.Label(new Rect(300, 100, 100, 20), (elapsedTime.ToString()));
    }
}
