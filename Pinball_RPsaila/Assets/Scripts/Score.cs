using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Created a list to help deal with all the added balls and their destruction
    // Help from : https://answers.unity.com/questions/627316/limit-instantiation.html
    // username : rutter

    //public GameObject[] balls;

    public List<GameObject> balls = new List<GameObject>();

    public TMPro.TextMeshPro multipliertext;
    public GameObject theball;
    public GameObject ballPrefab;

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
            //Debug.Log(balls.Count);
        }

        // CODE USED TEMPORARLY AND MOVED TO Game Over script
        // Because extra balls would disappear when pressing the Trigger Keys
        // Implement logic with Game Over script & GamerOverZone 
        // or detect movement along Y axis from balls or position to destroy them

        // when multiplier is back to normal, balls disappear

        //else if (multiplier  < 3)
        //{
        //   for (int i = 0; i < balls.Count; i++)
        //   {
        //       Destroy(balls[i]);
        // }
        //balls.Clear();
        //}
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