using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBounce : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move according to keys.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Debug.Log(x);
        Debug.Log(y);
        Vector3 moveDir = new Vector3(x, 0, y);
        this.transform.Translate(moveDir * Time.deltaTime);



    }
    void FixedUpdate()
    {
        /*Debug.Log("Herer");
        float floatStrength = 5.0f;
        GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);*/

        float floatingPosition = 3.0f;
        float floatStrength = 20.0f;
        if (transform.position.y < floatingPosition)
        {
            Debug.Log("force being applied upwards to move object up" + transform.position.y);
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
            //transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
        }
        if (transform.position.y >= floatingPosition)
        {
            Debug.Log("force applied is less than the gravitational force so that the object comes down. Here mass of object is 2.");
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 11.0f);
            //transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
        }
    }
}



