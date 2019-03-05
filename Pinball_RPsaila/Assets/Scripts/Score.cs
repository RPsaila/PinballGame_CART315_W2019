using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Created a list to help deal with all the added balls and their destruction
    // Help from : https://answers.unity.com/questions/627316/limit-instantiation.html
    // username : rutter

    public List<GameObject> balls = new List<GameObject>();

    public TMPro.TextMeshPro multipliertext;
    public GameObject theball;
    public GameObject ballPrefab;
    public GameObject[] newBalls;


    public int ballCount;
    public int maxBalls = 1;

    int score = 0;
    int multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        balls.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        this.GetComponent<TMPro.TextMeshPro>().text = score.ToString();
        multipliertext.text = "x" + multiplier.ToString();

        // if multiplier is equal to x3, it will add one ball
        if (multiplier == 3 && ballCount < maxBalls)
        {
            GameObject newBall = Instantiate(ballPrefab, theball.transform.position, theball.transform.rotation) as GameObject;
            ballPrefab.gameObject.tag = "SpawnedBalls";
            if (GameObject.FindGameObjectsWithTag("SpawnedBalls").Length > 1)
            {
                Debug.Log("it works!");
            }
            balls.Add(ballPrefab);
            ballCount++; 
        }


        else if (multiplier > 20)
        {
            ResetMultiplier();
            ballCount = 0;
            GameObject.FindGameObjectsWithTag("SpawnedBalls");
            newBalls = GameObject.FindGameObjectsWithTag("SpawnedBalls");
            foreach (GameObject SpawnedBalls in newBalls)
            {
                balls.Clear();
                Debug.Log(balls.Count);
                Destroy(SpawnedBalls);

            }
        }
    }

    public void AddScore(int points)
    {
        score = score + points * multiplier;
    }

    public void Addmultiplier(int multiplierpoints)
    {
        multiplier = multiplier + multiplierpoints;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetMultiplier()
    {
        multiplier = 1;
    }
}