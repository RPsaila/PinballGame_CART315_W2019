using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTest : MonoBehaviour
{
    private Vector3 initialposition;
    public GameObject theball;

    Score myScoreScript;
    public List<GameObject> balls;
    public GameObject[] newBalls;

    IEnumerator Start()
    {
        initialposition = theball.transform.position;
        myScoreScript = GetComponent<Score>();
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject.FindGameObjectsWithTag("SpawnedBalls");
        newBalls = GameObject.FindGameObjectsWithTag("SpawnedBalls");

        //KEEPING FOR LATER USE
        //foreach (GameObject SpawnedBalls in myScoreScript.balls)
        //{
        //    newBalls = GameObject.FindGameObjectsWithTag("SpawnedBalls");
        //}
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            theball.transform.position = initialposition;
        }

        //KEEPING FOR LATER USE
        //for (int i = 0; i < 3; i++)
        //{
            //if (newBalls[i] != null)
            //{
                if (collider.gameObject.tag == "SpawnedBalls")
                {
                    foreach (GameObject SpawnedBalls in newBalls)
                    {
                        SpawnedBalls.transform.localPosition = initialposition;//new Vector3(newBalls[i].transform.localPosition.x, newBalls[i].transform.localPosition.y, newBalls[i].transform.localPosition.z);
                    }
                }
            }
        }


//Looking to implement logic where the collider would also detect the spawned balls 

//{
//foreach (GameObject ball in balls)
//{
//Destroy(balls);
//    {
//balls.Clear();
//for (int i = 0; i < balls.Length; i++)
//{
//if (balls.Count > i)
//{


//}

//    }
//}
//}


//// Start is called before the first frame update
//void Start()
//{
//    initialposition = theball.transform.position;
//}

//// Update is called once per frame
//void FixedUpdate()
//{

//}

//private void OnTriggerEnter(Collider collider)
//{
//    if (collider.gameObject == theball)
//    {

//        //Looking to implement logic where the collider would also detect the spawned balls 

//        //{
//        //foreach (GameObject ball in balls)
//        //{
//        //Destroy(balls);
//        //    {
//        //balls.Clear();
//        {
//                theball.transform.position = initialposition;
//                //balls.transform.position = initialposition;
//                        }
//                    }
//                }
//    //        }
//    //    }
//    //}
//}



//void OnCollisionEnter(Collision col)
//{

//    // Add the GameObject collided with to the list.
//    currentCollisions.Add(col.gameObject);

//    // Print the List<GameObject> currentCollisions = new List<GameObject>();entire list to the console.
//    foreach (GameObject gObject in currentCollisions)
//    {
//        print(gObject.name);
//    }
//}

//void OnCollisionExit(Collision col)
//{

//    // Remove the GameObject collided with from the list.
//    currentCollisions.Remove(col.gameObject);

//    // Print the entire list to the console.
//    foreach (GameObject gObject in currentCollisions)
//    {
//        print(gObject.name);
//    }
//}