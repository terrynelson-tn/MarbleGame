using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has a specific tag
        if (other.CompareTag("Player"))
        {
            // Code to execute when the object collides with another object with the specified tag
            Debug.Log("Player Detected");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
