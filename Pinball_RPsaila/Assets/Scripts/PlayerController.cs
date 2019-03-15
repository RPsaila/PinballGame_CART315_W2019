using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code Adapted from https://unity3d.com/fr/learn/tutorials/projects/roll-ball-tutorial/moving-player?playlist=17141

public class PlayerController : MonoBehaviour
{
    GameOverTest myGameOverPinballScript;
    Score myScoreScript;

    //public bool PlayerControllerActivated;
    public float speed;

    public TMPro.TextMeshPro theScore;
    private int currentScore;

    private Rigidbody rb;

    void Start()
    {
        myScoreScript = GetComponent<Score>();
        currentScore = theScore.GetComponent<Score>().score;
        myGameOverPinballScript = GetComponent<GameOverTest>();
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        currentScore = theScore.GetComponent<Score>().score;
        if (currentScore >= 1500)
        {
            BallMovement();
        }
    }

   public void BallMovement()
    {
        Debug.Log("move");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}