using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlipper : MonoBehaviour
{
    public Score thescore;
    public string button = "LeftFlipper";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton(button))
        {
            this.GetComponent<HingeJoint>().useMotor = true;
            thescore.ResetMultiplier();
        }
        else
        {
            this.GetComponent<HingeJoint>().useMotor = false;
        }
    }
}