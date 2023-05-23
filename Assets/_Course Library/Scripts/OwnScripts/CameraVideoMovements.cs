using UnityEngine;

public class CameraVideoMovements : MonoBehaviour
{
    public Transform target; // Target object around which the camera will rotate
    public float rotationSpeed = 1f; // Speed of rotation

    private Vector3 offset; // Offset between camera and target

    private void Start()
    {
        // Calculate the initial offset between camera and target
        offset = transform.position - target.position;
    }

    private void Update()
    {
        // Calculate the desired position based on the target and rotation speed
        Quaternion rotation = Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
        offset = rotation * offset;

        // Set the new camera position based on the target and offset
        transform.position = target.position + offset;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}

