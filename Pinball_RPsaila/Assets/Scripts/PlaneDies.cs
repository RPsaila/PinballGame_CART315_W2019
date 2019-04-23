using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adapted from CART 416 project

public class PlaneDies : MonoBehaviour
{
    public GameObject PlanesManager;

    private List<GameObject> planes;


    // Start is called before the first frame update

    IEnumerator Start()
    {
        planes = PlanesManager.GetComponent<GeneratePlanes>().planes;
        yield return new WaitForEndOfFrame();

    }

    // Update is called once per frame
    public void FixedUpdate()
    {

    }

    public void OnCollisionEnter(Collision enemy)
    {

        //Debug.Log("works");
        if (enemy.gameObject.tag == "Plane")
        {

            for (int i = planes.Count - 1; i >= 0; i--)
            {
                if (planes[i].gameObject.Equals(enemy.gameObject))
                {
                    StartCoroutine(Die());

                    IEnumerator Die()
                    {
                        if (enemy.gameObject.tag == "Plane")
                        {
                            planes.Remove(planes[i].gameObject);
                            Destroy(planes[i].gameObject);
                            yield return new WaitForSeconds(0.5f);
                        }

                    }
                }
            }
        }
    }
}