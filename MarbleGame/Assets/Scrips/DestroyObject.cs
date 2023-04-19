using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject deleteMe;
    // Update is called once per frame
    void Update()
    {
        Destroy(deleteMe, 60f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
        }
    }
}
