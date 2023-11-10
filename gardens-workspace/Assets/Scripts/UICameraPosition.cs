// This script is for UI elements to face the user through the rotation of the camera

// <summary>
// Control the rotation of a collection of specified objects based on the rotation of the main camera.

// Quaternion.Slerp (Spherical Linear Interpolation) to interpolate between the current 
// rotation of each object and the camera's rotation
// <summary>

using UnityEngine;

public class UICameraPosition : MonoBehaviour
{
    public Transform[] objectsToRotate; // An array of objects to rotate

    private void Update()
    {
        Quaternion targetRotation = Camera.main.transform.rotation;

        foreach (Transform objToRotate in objectsToRotate)
        {
            // Use Quaternion.Slerp to smoothly interpolate between the object's current rotation
            // and the camera's rotation
            objToRotate.rotation = Quaternion.Slerp(
                objToRotate.rotation,
                targetRotation,
                3f * Time.deltaTime
            );
        }
    }
}
