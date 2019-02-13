using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    private Vector3 initialposition;
    public GameObject theball;
    public List<GameObject> balls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        initialposition = theball.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == theball)
        {

            //Looking to implement logic where the collider would also detect the spawned balls 

            //{
                //foreach (GameObject ball in balls)
                //{
                //Destroy(balls);
                //    {
                //balls.Clear();
                        {
                    theball.transform.position = initialposition;
                    //balls.transform.position = initialposition;
                            }
                        }
                    }
        //        }
        //    }
        //}
    }



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
