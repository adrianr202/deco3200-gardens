using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject mainCamera;
    public MonoBehaviour[] scriptsToDisable;

    private void Update()
    {
        if (mainCamera.activeSelf)
        {
            foreach (var script in scriptsToDisable)
            {
                script.enabled = false;
            }
        }
        else
        {
            foreach (var script in scriptsToDisable)
            {
                script.enabled = true;
            }
        }
    }
}
