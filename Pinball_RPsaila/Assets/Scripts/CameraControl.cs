using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Code Adapted from : https://answers.unity.com/questions/16146/changing-between-cameras.html

    Score myScoreScript;

    // Define additional GameObjects
    public GameObject theScore;
    private int currentScore;

    // Define Cams
    public Camera lobbyCam;
    public Camera thirdPlayerCam;

    // Define Buttons
    //public string lobbyCamButton;
    //public string playerCamButton;

    //Define List of Cameras
    //public List<Camera> cameras = new List<Camera>();

    private void Awake()
    {
        thirdPlayerCam.enabled = false;
    }

    void Start()
    {
        // Add inspector Cameras here
        //cameras.Add(lobbyCam);
        currentScore = theScore.GetComponent<Score>().score;
        Debug.Log(currentScore);
    }

    void Update()
    {
        currentScore = theScore.GetComponent<Score>().score;
        Debug.Log(currentScore);
        // Check for score and swap accordingly
        if (currentScore >= 10)
        {
            lobbyCam.enabled = false;
            thirdPlayerCam.enabled = true;
        }
    }
}
