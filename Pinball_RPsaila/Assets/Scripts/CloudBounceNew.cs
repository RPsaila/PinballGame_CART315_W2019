using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBounceNew : MonoBehaviour
{

    public GameObject player;

    public float cloudFloatingPosition;


    // Use this for initialization
    void Start()
    {

    cloudFloatingPosition = transform.position.y + 5;

    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {


    }

    public void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<PlayerController>().timer = 200;
        player.GetComponent<PlayerController>().playerFloatingPosition = cloudFloatingPosition;

        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);

        this.GetComponent<AudioSource>().Play();

    }

}



