using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Adapted from group class project for CART315

public class GameControl : MonoBehaviour {

    GameObject statsPanel;
    GameObject menuPanel;

    public float healthScore;
    public int timeScore;
    private int overallScore;

    public GameObject player;
    public GameObject scoreObject;

    public bool startTimer;
    public static float timer;
    private int minutes;
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.FindGameObjectWithTag("Menu");
        statsPanel = GameObject.FindGameObjectWithTag("Stats");

        Time.timeScale = 0;
        menuPanel.SetActive(true);
        statsPanel.SetActive(false);

        player = GameObject.FindWithTag("Player");

        startTimer = false;

        healthScore = 100.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        //GetHealth();

        //if (timeScore <= 0)
        //{
        //    SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        //}

        if (startTimer == true)
        {

            GetTime();
            GetNewScore();

        }
        else if (startTimer == false)
        {
            timer = 0;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        statsPanel.SetActive(true);
        GetTime();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }


    //void GetHealth()
    //    {
    //        //if (startTimer == false)
    //        //{

    //           healthScore = 100.0f;

    //        //}

    //        //else if (startTimer == true)
    //        //{

    //        //healthScore -= 0.03f;

    //        //}

    //}

    void GetTime()
    {
        timer += Time.deltaTime;
        timeScore = seconds;
        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
    }


    void GetNewScore()
    {
        if (player.GetComponent<Rigidbody>().velocity.magnitude > 0 && timer != 0f)
        {
            overallScore = scoreObject.GetComponent<ScorePinball>().score + timeScore;
        }

        else if (startTimer == false)
        {
            timeScore = 0;
        }
    }

}

