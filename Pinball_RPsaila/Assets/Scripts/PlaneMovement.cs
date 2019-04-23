using System.Collections;
using System.Collections.Generic;  
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    //public float Speed;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaneMoves()
    {
        transform.Translate(Vector3.forward * (Random.value * Random.Range(0.75f, 1.4f)));
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
         
            //Debug.Log("collisiondetectedwithplayer");
            this.GetComponent<BoxCollider>().enabled = false;
          
        }
    }
}
