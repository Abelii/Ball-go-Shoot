using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    float smoothSpeed = 0.03f;

    void Start() 
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate() 
    {
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = target.position + new Vector3(0, 0, -10);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        transform.position = smoothedPosition;
    }

}
