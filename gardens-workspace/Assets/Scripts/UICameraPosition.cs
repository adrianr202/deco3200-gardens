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
