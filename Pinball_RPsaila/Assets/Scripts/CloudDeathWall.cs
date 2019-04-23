using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not working...

public class CloudDeathWall : MonoBehaviour
{

    public GameObject movingCloudParent;
    private Vector3 initialposition;

    // Start is called before the first frame update
    void Start()
    {

        initialposition = movingCloudParent.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("detected");
        if (collision.gameObject.tag == "MovingCloudParent")
        {

            movingCloudParent.transform.position = initialposition;

        }

    }

}
