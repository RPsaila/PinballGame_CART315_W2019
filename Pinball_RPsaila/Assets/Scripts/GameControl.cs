using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    GameObject statsPanel;
    GameObject menuPanel;

    public float healthScore;
    public int timeScore;
    private int overallScore;

    public GameObject player;
    public bool startTimer;
    public static float timer;
    private int minutes;
    private int seconds;

    public int pastAte;

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

        GetTime();
        GetNewScore();
        //GetHealth();

        //if (timeScore <= 0)
        //{
        //    SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        //}
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


    void GetNewScore()
    {
        if (startTimer == true && player.GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            timeScore = timeScore + seconds++;
        }

        else if (startTimer == false)
        {
            timeScore = 0;
        }
    }


    void GetTime()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
    }

}

