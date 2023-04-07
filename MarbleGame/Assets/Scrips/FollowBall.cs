using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;
    public float distance = 5.0f;
    public float height = 2.0f;

    void LateUpdate()
    {
        // Calculate the offset between the ball and the camera
        Vector3 offset = new Vector3(0, height, -distance);

        // Set the camera's position relative to the ball
        transform.position = ball.position + offset;

        // Make the camera look at the ball
        transform.LookAt(ball);
    }
}

