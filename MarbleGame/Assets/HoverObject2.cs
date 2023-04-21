using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject2 : MonoBehaviour
{
    public float floatForce = 10f;
    bool hover = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hover)
            rb.AddForce(Vector3.up * floatForce);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            rb = other.GetComponent<Rigidbody>();
            hover = true;
            
        }
    }
    void OnTriggerExit(Collider other) {
        Debug.Log("Player exited trigger")    ;
        hover = false;
    }
}
