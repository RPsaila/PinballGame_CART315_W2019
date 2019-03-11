using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSave : MonoBehaviour
{
    private Vector3 initialposition;
    public GameObject InitialPlayer;
    public Vector3 ThirdPlayer;

    public Score MyScoreScript;
    public List<GameObject> balls;
    public GameObject[] newBalls;

    // Start is called before the first frame update
    void Start()
    {
        MyScoreScript = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveInitialBallPosition()
    {
        PlayerPrefs.SetFloat("PlayerX", InitialPlayer.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", InitialPlayer.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", InitialPlayer.transform.position.z);
    }

    public void SaveThirdPlayerBallPosition()
    {
        if (MyScoreScript.score == 5000)
        {
            PlayerPrefs.SetFloat("ThirdPlayerX", ThirdPlayer.x);
            PlayerPrefs.SetFloat("ThirdPlayerY", ThirdPlayer.y);
            PlayerPrefs.SetFloat("ThirdPlayerZ", ThirdPlayer.z);
        }
    }

    public void Load()
    {
        InitialPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

        InitialPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("ThirdPlayerX"), PlayerPrefs.GetFloat("ThirdPlayerY"), PlayerPrefs.GetFloat("ThirdPlayerZ"));
    }
}
