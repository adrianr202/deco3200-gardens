// <summary>
// Activate and deactivate a list of specified GameObjects when triggered through a button onclick event
// Specifically to toggle UI elements when button is pressed 
// <summary>

// Public Input:
// objectsToActivate: An array containing references to the GameObjects you want to activate.
// objectsToDeactivate: An array containing references to the GameObjects you want to deactivate.

using UnityEngine;
using UnityEngine.UI;

public class ExecuteTrigger : MonoBehaviour
{
    public GameObject[] objectsToActivate; // References to the GameObjects you want to activate
    public GameObject[] objectsToDeactivate; // References to the GameObjects you want to deactivate

    public void ActivateObjects()
    {
        // Debugging purposes
        // Debug.Log("Button clicked. Activating and deactivating objects.");
        
        // Activate specified GameObjects
        foreach (var obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        // Deactivate specified GameObjects
        foreach (var obj in objectsToDeactivate)
        {
            if (obj != null) 
            {
                obj.SetActive(false);
            }
        }
    }
}
