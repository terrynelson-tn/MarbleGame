//Final Project --- FallingMarbles.cs by Sebastian Ulloa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMarbles : MonoBehaviour
{
    public GameObject MarblePrefab;
    private GameObject Marble;
    [SerializeField] private Material[] randomMaterial;
    List<GameObject> totalMarbles = new List<GameObject>();

    private float time = 0.0f;

    void Awake()
    {
        Marble = Instantiate(MarblePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 randomSpawnPosition = new(Random.Range(-10, 11), transform.position.y, Random.Range(-5, 11));

        if (time > 0.2f)
        {
            totalMarbles.Add(Instantiate(Marble, randomSpawnPosition, Quaternion.identity) as GameObject);
            foreach (GameObject Marble in totalMarbles)
            {
                StartCoroutine(MarbleTime());
            }
            time = 0.0f;
        }
    }




    IEnumerator MarbleTime()
    {
        Marble.GetComponent<Renderer>().material = randomMaterial[Random.Range(0, randomMaterial.Length)];
        yield return new WaitForSeconds(3f);
        if (totalMarbles.Count > 0)
        {
            totalMarbles.RemoveAt(0);
        }
    }
}