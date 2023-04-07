using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ballTransform;
    public float cameraHeight = 5f;
    public float cameraDistance = 10f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - ballTransform.position;
    }

    void LateUpdate()
    {
        // Update camera position to follow ball
        transform.position = ballTransform.position + offset;

        // Keep camera level with horizon
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = cameraHeight;
        transform.position = cameraPosition;

        // Keep camera distance from ball
        transform.LookAt(ballTransform);
        transform.position -= transform.forward * cameraDistance;

        // Prevent camera roll when ball rolls
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
