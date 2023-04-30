//Final Project --- FallingMarbles.cs by Sebastian Ulloa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMarbles : MonoBehaviour
{
    public GameObject MarblePrefab;
    [SerializeField] private Material[] randomMaterial;
    ArrayList totalMarbles = new ArrayList();
    private GameObject newMarble;

    public float despawnTime = 2f;
    public float minXRange = -10;
    public float maxXRange = 11;
    public float minZRange = -5;
    public float maxZRange = 11;

    private float time = 0.0f;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 randomSpawnPosition = new(Random.Range(transform.position.x + minXRange, transform.position.x + maxXRange), transform.position.y, Random.Range(transform.position.z + minZRange, transform.position.z + maxZRange));

        if (time > 0.1f)
        {
            newMarble = Instantiate(MarblePrefab, randomSpawnPosition, Quaternion.identity);
            totalMarbles.Add(newMarble);
            StartCoroutine(MarbleTime());
            time = 0.0f;
        }

    }

    IEnumerator MarbleTime()
    {
        MarblePrefab.GetComponent<Renderer>().material = randomMaterial[Random.Range(0, randomMaterial.Length)];
        Destroy(newMarble, despawnTime);
        yield return new WaitForSeconds(3f);
    }
}