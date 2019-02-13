using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    private Vector3 initialposition;
    public GameObject theball;

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
            theball.transform.position = initialposition;
        }
    }
}
