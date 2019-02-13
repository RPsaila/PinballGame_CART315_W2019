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

    public int maxBalls = 3;
    public GameObject ballPrefab;

    int score = 0;
    int multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        this.GetComponent<TMPro.TextMeshPro>().text = score.ToString();
        multipliertext.text = "x" + multiplier.ToString();

        // if multiplier is equal to x3, it will add two balls

        if (multiplier == 3 && balls.Count < maxBalls)
        {
        GameObject ball = Instantiate(ballPrefab);
        balls.Add(ball);
        }

        // when multiplier is back to normal, balls disappear

        // CODE USED TEMPORARLY AND MOVED TO Game Over script
        // Because extra balls would disappear when pressing the Trigger Keys
        // Implement logic with Game Over script & GamerOverZone 
        // or detect movement along Y axis from balls or position to destroy them

        // else if (multiplier  < 3)
        // {
        //foreach (GameObject ball in balls)
        //  {
        //Destroy(ball);
        //  }
        // balls.Clear();
        // }
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