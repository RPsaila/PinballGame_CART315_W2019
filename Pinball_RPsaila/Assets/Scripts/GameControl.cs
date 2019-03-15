//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Help from Unity Data Persistence Live https://www.youtube.com/watch?v=J6FfcJpbPXE

//public class GameControl : MonoBehaviour
//{
//    public static GameControl control;

//    public float health;
//    public float experience;

//    // Start is called before the first frame update
//    void Awake ()
//    {
//        if(control == null)
//        {
//            DontDestroyOnLoad(gameObject);
//            control = this;
//        }
//        else if(control != this)
//        {
//            Destroy(gameObject);
//        }
//    }

//    void OnGui()
//    {
//        GUI.Label(new Rect(10, 10, 100, 30), "Health:" + health);
//        GUI.Label(new Rect(10, 10, 100, 30), "Experience:" + experience);
//    }

//}
