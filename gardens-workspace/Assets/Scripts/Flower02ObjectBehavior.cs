using UnityEngine;

public class Flower02ObjectBehavior : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element you want to show/hide
    public GameObject childObject; // Reference to the child object with the collider

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch detected on Flowers_02.");
            // uiElement.SetActive(true); // Show the UI element
        }
    }
}
