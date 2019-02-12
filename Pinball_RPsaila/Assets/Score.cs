using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;
    int multiplier = 1;

    public TMPro.TextMeshPro multipliertext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        this.GetComponent<TMPro.TextMeshPro>().text = score.ToString();
    }

    public void AddScore(int points)
    {
        score = score + points * multiplier;
    }

    public void Addmultiplier (int multiplierpoints)
    {
        multiplier = multiplierpoints + multiplierpoints;
    }
    public void ResetScore()
    {
        score = 0;
    }

    public void ResetMultiplier()
    {
        multiplier = 0;
    }
}
