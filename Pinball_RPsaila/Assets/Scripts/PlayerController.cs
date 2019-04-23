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
    public float maximumSpeed;
    public float JumpForce;

    public TMPro.TextMeshPro theScore;
    private int currentScore;

    private Rigidbody rb;

    public int timer = 0;
    public float playerFloatingPosition;

    private bool isJumping;

    private List<AudioSource> soundList = new List<AudioSource>();

    void Start()
    {
        myScoreScript = GetComponent<ScorePinball>();
        currentScore = theScore.GetComponent<ScorePinball>().score;
        myGameOverPinballScript = GetComponent<GameOverTest>();
        rb = GetComponent<Rigidbody>();
        //speed = Vector3.Magnitude(GetComponent<Rigidbody>().velocity);
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

    public void OnCollisionEnter(Collision collision)
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
            //GetComponent<SphereCollider>().enabled = false;
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

    // Adapted code from https://answers.unity.com/questions/408115/play-audio-sources-in-trigger-zone-when-player-ent.html for Player Audio Management
    // Tested and not working....

    //void OnTriggerEnter(BoxCollider other)
    //{
    //    if (other.tag == "Plane")
    //    {
    //        soundList.Add(other.GetComponent<AudioSource>());  // add it to the list
    //        PlaySound();
    //    }
    //}

    //void OnTriggerExit(BoxCollider other)
    //{   
    //    if (other.tag == "Plane")
    //    { // sound object leaving the trigger?
    //        soundList.Remove(other.GetComponent<AudioSource>()); // yes: remove it from the list
    //        StopSound();
    //    }
    //}

    //void PlaySound()
    //{
    //    foreach (AudioSource sound in soundList)
    //    { // play all sounds in the list
    //        sound.Play();
    //    }
    //}

    //void StopSound()
    //{
    //    foreach (AudioSource sound in soundList)
    //        {
    //        sound.Stop(); // yes: stop all sounds in the list

    //    }
    //}
      
 //if (speed > maximumSpeed)
 
 // {
 //     float brakeSpeed = speed - maximumSpeed;  // calculate the speed decrease

 //   Vector3 normalisedVelocity = rigidbody.velocity.normalized;
 //   Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value

 //   rigidbody.AddForce(-brakeVelocity);  // apply opposing brake force
 // }
}