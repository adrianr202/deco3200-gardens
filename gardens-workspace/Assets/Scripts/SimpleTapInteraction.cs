using UnityEngine;

public class SimpleTapInteraction : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("GameObject was tapped.");
        }
    }
}
