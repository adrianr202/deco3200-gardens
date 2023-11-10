// <summary>
// Manage the Flower model activation and deactivation in response to user interactions
// Revealing hidden objects, triggering animations and specifically for UI elements to appear
// <summary>

// When user input is detected, the script performs the following actions:
// It checks for touch or mouse input.
// It casts a ray from the camera through the input position for raycasting.
// If the ray hits the GameObject associated with the script, it activates objectToActivate.
// Additionally, it deactivates the GameObjects specified in objectsToDeactivate.

// Public Inputs:
// objectToActivate: A reference to the GameObject you want to activate.
// objectsToDeactivate: A list of GameObjects you want to deactivate.

using UnityEngine;
using System.Collections.Generic;

public class FlowerObjectBehavior : MonoBehaviour
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
