using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject deleteMe;
    public AudioSource death;
    public MeshRenderer mesh;

    private void Start()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(deleteMe, 60f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            mesh.enabled = false;
            death.PlayOneShot(death.clip, 1);
            Destroy(this.gameObject, 2f);
        }
    }
}
