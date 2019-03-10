using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOT USED CURRENTLY 
// THOUGHT ABOUT IMPLEMENTING IT WITH THE LIST OF BALLS AND THE Game Over Script
// Code taken from https://answers.unity.com/questions/903780/how-do-i-get-list-of-all-objects-touching-during-a.html
// Username : reinfeldx

public class CollisionList : MonoBehaviour
{

    // Declare and initialize a new List of GameObjects called currentCollisions.
    List<GameObject> currentCollisions = new List<GameObject>();

    void OnCollisionEnter(Collision col)
    {

        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);

        // Print the entire list to the console.
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }

    void OnCollisionExit(Collision col)
    {

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);

        // Print the entire list to the console.
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }
}