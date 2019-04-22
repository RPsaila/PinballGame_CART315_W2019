using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adapted from class project script for chickens made by Nina Parenteau

public class GeneratePlanes : MonoBehaviour
{

    public GameObject plane;
    List<GameObject> planes;
    public int nbPlanes;
    public int nbPlanesAllowed = 15;


    public static Vector3 location;

    private const float valueY = 10.21f;


    // Start is called before the first frame update
    void Start()
    {

        planes = new List<GameObject>();
        GenerateThem();

    }

    // Update is called once per frame
    void Update()
    {
        planes.RemoveAll(GameObject => GameObject == null);
        nbPlanes = planes.Count;
        print(nbPlanes);
    }

    void GenerateThem()
    {
        for (int i = 0; i <= nbPlanesAllowed; i++)
        {
            location = new Vector3(Random.Range(127.0f, 172.0f), valueY, Random.Range(40.0f, 131.0f));
            AddToList();
        }
    }

    void AddToList()
    {
        planes.Add((GameObject)Instantiate(plane, location, Quaternion.Euler(0, 0, 0)));
    }
}
