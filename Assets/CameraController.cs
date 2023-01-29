using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float distance = 10f; // The distance at which the camera should follow the target
    public float sensitivity = 5f; // The sensitivity of the mouse control
    public float verticalDisplacement = 5f;

    private float yaw = 0f; // The yaw rotation of the camera
    private float pitch = 0f; // The pitch rotation of the camera

    private void Update()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Update the camera's yaw and pitch rotations based on the mouse input
        yaw += mouseX;
        pitch += mouseY;

        // Clamp the pitch rotation to prevent the camera from flipping upside down
        pitch = Mathf.Clamp(pitch, -89f, -10f);

        // Set the camera's position to the target's position plus the desired distance in the direction of the rotated camera
        transform.position = target.position  + (Quaternion.Euler(pitch, yaw, 0) * Vector3.forward * distance);

        // Set the camera's rotation to match the target's rotation
        transform.LookAt(target);
        transform.position += Vector3.up*verticalDisplacement;
    }
}
