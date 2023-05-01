//Final Project --- ActivatePlatform.cs by Sebastian Ulloa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{
    public GameObject Platform;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
            Platform.SetActive(true);
    }
}
