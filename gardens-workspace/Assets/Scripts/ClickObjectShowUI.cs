using UnityEngine;

public class ClickObjectShowUI : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element you want to show

    private void Start()
    {
        // Ensure the UI element is initially set to inactive
        uiElement.SetActive(false);
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {

            Debug.Log("Mouse click detected");
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this GameObject
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // The GameObject was clicked
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
