// activate a UI element when a specific game object is clicked.

// Public Input:
// uiElement: A reference to the UI element you want to show.

using UnityEngine;

public class ClickObjectShowUI : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element you want to show

    public void ActivateObjects()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
    
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this GameObject
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // Debug purposes
                // Debug.Log("ShowUI Activated");
                ShowUI();
            }
        }
    }

    // Show the UI element
    private void ShowUI()
    {
        uiElement.SetActive(true);
    }
}
