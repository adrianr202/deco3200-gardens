//  <summary>
//  Managing the activation and deactivation of specific scripts within a target GameObject
//  Modular way to control script activation states
//  <summary>


using UnityEngine;

public class ActivationController : MonoBehaviour
{
    public GameObject targetObject; // The GameObject that contains the scripts to activate
    public MonoBehaviour[] scriptsToActivate;

    private void OnEnable()
    {
        // Automatically activate scripts when this GameObject becomes active
        ActivateScripts();
    }

    private void OnDisable()
    {
        // Automatically deactivate scripts when this GameObject becomes inactive
        DeactivateScripts();
    }

    public void ActivateScripts()
    {
        foreach (var script in scriptsToActivate)
        {
            script.enabled = true;
        }
    }

    public void DeactivateScripts()
    {
        foreach (var script in scriptsToActivate)
        {
            script.enabled = false;
        }
    }
}
