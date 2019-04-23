using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adapted from class project script for chickens made by Nina Parenteau

public class GeneratePlanes : MonoBehaviour
{

    public GameObject plane;
    public List<GameObject> planes;
    public int nbPlanes;
    public int nbPlanesAllowed;


    public static Vector3 location;
    public static Quaternion rotation;

    // Tried to set up more precise random values for positions of planes, didn't succeed
    // Got help from https://answers.unity.com/questions/1247462/how-to-generate-a-random-number-which-is-different.html

    //private float lastNumberX;
    //private float lastNumberY;
    //private float lastNumberZ;

    //private float randomX;
    //private float randomY;
    //private float randomZ;

    //private const float valueY = 10f;

    // Start is called before the first frame update
    void Start()
    {

        planes = new List<GameObject>();
        //StartCoroutine(GenerateRandomX());
        //StartCoroutine(GenerateRandomY());
        //StartCoroutine(GenerateRandomZ());
        StartCoroutine(GenerateThem());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        planes.RemoveAll(GameObject => GameObject == null);
        nbPlanes = planes.Count;

        for (int i = 0; i < planes.Count; i++)
        {
            planes[i].GetComponent<PlaneMovement>().PlaneMoves();
        }

        //print(nbPlanes);
    }

    // Tried to set up more precise random values for positions of planes, didn't succeed
    // Got help from https://answers.unity.com/questions/1247462/how-to-generate-a-random-number-which-is-different.html

    //IEnumerator GenerateRandomX()
    //{
    //    float minX = 8f;
    //    float maxX = 30f;

    //    randomX = Random.Range(minX, maxX);
    //    while (randomX == lastNumberX)
    //        randomX = Random.Range(minX, maxX);
    //    lastNumberX = randomX;
    //    yield return new WaitForSeconds(1f);
    //}

    //IEnumerator GenerateRandomY()
    //{
    //    float minY = -25f;
    //    float maxY = 30f;

    //    randomY = Random.Range(minY, maxY);
    //    while (randomY == lastNumberY)
    //        randomY = Random.Range(minY, maxY);
    //    lastNumberY = randomY;
    //    yield return new WaitForSeconds(1f);
    //}

    //IEnumerator GenerateRandomZ()
    //{
    //    float minZ = 300f;
    //    float maxZ = 400f;

    //    randomZ = Random.Range(minZ, maxZ);
    //    while (randomZ == lastNumberZ)
    //        randomZ = Random.Range(minZ, maxZ);
    //    lastNumberZ = randomZ;
    //    yield return new WaitForSeconds(1f);
    //}

    IEnumerator GenerateThem()
    {
        for (int i = 0; i <= nbPlanesAllowed; i++)
        {          
            location = new Vector3(this.transform.position.x + Random.Range(5f, 30f), this.transform.position.y + Random.Range(-22.0f, -34.0f), this.transform.position.z + Random.Range(150f, 300f));
            rotation = new Quaternion(0, -180, 0, 0);  
            AddToList();

            StartCoroutine(WaitBetweenEachSpawn());

            yield return new WaitForSeconds(2f);
        }

        yield return new WaitForSeconds(1f);

    }

    public IEnumerator WaitBetweenEachSpawn()
    {
        //Debug.Log("wait");
        yield return new WaitForSeconds(1f);
    }

    void AddToList()
    {
        planes.Add((GameObject)Instantiate(plane, location, rotation));
    }

    // Potential for adding a second wave at different locations.

    //void GenerateWave2()
    //{
    //    for (int i = 0; i <= nbPlanesAllowed; i++)
    //    {
    //        location = new Vector3(Random.Range(8f, 50f), valueY, Random.Range(300.0f, 450f));
    //        rotation = new Quaternion(0, -180, 0, 0);
    //        AddToList();
    //    }
    //}

}
