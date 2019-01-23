using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public string button = "Launch";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton(button))
        {
            this.GetComponent<ConstantForce>().enabled = true; 
        }
        else 
        {
            this.GetComponent<ConstantForce>().enabled = false; 
        }
    }
}
