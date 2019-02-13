using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Created a list to help deal with all the added balls and their destruction

    List<GameObject> balls = new List<GameObject>();

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
        GameObject ball = (GameObject)Instantiate(ballPrefab);
        balls.Add(ball);
        }

        // when multiplier is back to normal, balls disappear

        else if (multiplier < 3)
        {
            foreach (GameObject ball in balls)
            {
                Destroy(ball);
            }
            balls.Clear();
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