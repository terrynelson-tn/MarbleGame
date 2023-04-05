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

    private float time = 0.0f;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Vector3 randomSpawnPosition = new(Random.Range(-10, 11), transform.position.y, Random.Range(-5, 11));

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
        Destroy(newMarble, 2f);
        yield return new WaitForSeconds(3f);
    }
}