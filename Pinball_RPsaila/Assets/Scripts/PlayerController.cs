using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code Adapted from https://unity3d.com/fr/learn/tutorials/projects/roll-ball-tutorial/moving-player?playlist=17141

public class PlayerController : MonoBehaviour
{
    // Jump adapted & Checkpoint Code taken from https://github.com/santiandrade/Unity-CheckPoints

    GameOverTest myGameOverPinballScript;
    ScorePinball myScoreScript;

    public GameObject GameControlObject;

    public float speed;
    public float JumpForce;

    public TMPro.TextMeshPro theScore;
    private int currentScore;

    private Rigidbody rb;

    public int timer = 0;
    public float playerFloatingPosition;

    private bool isJumping;
    private bool colliderIsOn;

    void Start()
    {
        myScoreScript = GetComponent<ScorePinball>();
        currentScore = theScore.GetComponent<ScorePinball>().score;
        myGameOverPinballScript = GetComponent<GameOverTest>();
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        currentScore = theScore.GetComponent<ScorePinball>().score;
        if (currentScore >= 10)
        {
            BallMovement();

            if (timer > 0)
            {

                timer--;

                float floatStrength = 10.0f;

                if (transform.position.y < playerFloatingPosition)
                {
                    Debug.Log("force being applied upwards to move object up" + transform.position.y);
                    this.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
                    //transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
                }
                if (transform.position.y >= playerFloatingPosition)
                {
                    Debug.Log("force applied is less than the gravitational force so that the object comes down. Here mass of object is 2.");
                    this.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 11.0f);
                    //transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
                }

            }
        }
    }

   public void BallMovement()
    {
        //Debug.Log("move");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveJump = Input.GetAxis("Jump");

        Vector3 sideMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Vector3 jumpMovement = new Vector3(0.0f, moveJump, 0.0f);

        rb.AddForce(sideMovement * speed);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            rb.AddForce(jumpMovement * JumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collisiondetected");
        isJumping = false;

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collisiondetectedwithenemy");
            transform.position = CheckPoint.GetActiveCheckPointPosition();
        }
        if (collision.gameObject.tag == "Plane")
        {
            //WE WANT THIS ON THE PLANE NOT THE PLAYER
            Debug.Log("collisiondetectedwithplane");
            GetComponent<SphereCollider>().enabled = false;
            GameControlObject.GetComponent<GameControl>().healthScore = GameControlObject.GetComponent<GameControl>().healthScore - 10f;
        }
        if (collision.gameObject.tag == "Coin")
        {
            GameControlObject.GetComponent<GameControl>().healthScore = GameControlObject.GetComponent<GameControl>().healthScore + 10f;
        }
        //if (collision.other 
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("collisiondetectedwithenemy");
        //    transform.position = CheckPoint.GetActiveCheckPointPosition();
        //}
    }


    //void IsColliderOn()
    //{
    //    if (colliderIsOn == true)
    //    {
    //        GetComponent<Rigidbody>().enabled = true;
    //        GetComponent<SphereCollider>().isTrigger = true;
    //    }
    //    if (colliderIsOn == false)

    //    {
    //        GetComponent<SphereCollider>().isTrigger = false;

    //    }

    //}




}