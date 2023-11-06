using UnityEngine;
using System.Collections.Generic;

public class Flower02ObjectBehavior : MonoBehaviour
{
    public GameObject objectToActivate; // Reference to the game object you want to activate
    public List<GameObject> objectsToDeactivate; // Reference to the game object you want to activate

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            // Check if a touch began
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                HandleInput();
            }
        }
        else if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        // Debug.Log("Input Detected");

        // Create a ray from the camera through the touch position or mouse position
        Ray ray;
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        }
        else
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        // Add a debug line to visualize the ray
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        RaycastHit hit;

        // Check if the ray hits this game object
        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);

            // The game object was tapped or clicked, activate the other game object
            objectToActivate.SetActive(true);
            
            // Deactivate other objects in the list
            foreach (var obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
        }
    }
}
