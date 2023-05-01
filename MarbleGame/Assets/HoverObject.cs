using UnityEngine;

public class HoverObject : MonoBehaviour
{
    public float hoverForce = 10f; // the force to apply to the object when it's above the plane
    //public Transform hoverPlane; // the plane object that the object should hover above
                                 //public GameObject hoverPlane;


    //public GameObject planeObject;
    public GameObject objectToCheck;
    public Rigidbody rb;



    float xMin;
    float xMax;
    float zMin;
    float zMax;
    private void Start()
    {

        Bounds bounds = gameObject.GetComponent<Renderer>().bounds;
        xMin = bounds.min.x;
        xMax = bounds.max.x;
        zMin = bounds.min.z;
        zMax = bounds.max.z;
        Debug.Log("xMin:" + xMin);
        Debug.Log("xMax:" + xMax);
        Debug.Log("zMin:" + zMin);
        Debug.Log("zMax:" + zMax);
        rb = objectToCheck.GetComponent<Rigidbody>();

    }

    private void Update()
    {

    }
    void FixedUpdate()
    {
        Debug.Log("marble z pos:" + rb.transform.position.z);
        Debug.Log("marble x pos:" + rb.transform.position.x);
        if (rb.transform.position.z > zMin && rb.transform.position.z < zMax && rb.transform.position.x > xMin && rb.transform.position.x < xMax)
        {
            Debug.Log("within bounds");
            rb.AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
        }
    }
}

