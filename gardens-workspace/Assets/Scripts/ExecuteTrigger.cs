using UnityEngine;
using UnityEngine.UI;

public class ExecuteTrigger : MonoBehaviour
{
    public GameObject[] objectsToActivate; // References to the GameObjects you want to activate
    public GameObject[] objectsToDeactivate; // References to the GameObjects you want to deactivate

    public void ActivateObjects()
    {

        Debug.Log("Button clicked. Activating and deactivating objects.");
        
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
