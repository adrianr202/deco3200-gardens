using System.Collections.Generic;
using UnityEngine;

public class ARHitPlace : MonoBehaviour
{
    public Camera arCamera;          // Reference to your AR Camera.
    public GameObject placementObject;  // The object to place when a valid hit is detected.

    private List<GameObject> placedObjects = new List<GameObject>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("ARPlane")))
                {
                    // Instantiate the placement object at the hit point.
                    GameObject placedObject = Instantiate(placementObject, hit.point, Quaternion.identity);
                    placedObjects.Add(placedObject);
                }
            }
        }
    }
}
