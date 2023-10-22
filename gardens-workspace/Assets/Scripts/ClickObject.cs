using UnityEngine;

public class ClickObject : MonoBehaviour

{
    
    private Camera camera;
    public GameObject uiPanel; // Reference to the UI Panel
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        uiPanel.SetActive(false); //UI Panel deactivated
    }

    // Update is called once per frame
    void Update()
    {
       DetectObjectWithRaycast();
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);
                    ShowUI(); // Activated when input is registered, Changes ShowUI boolean value
            }
        }
    }

    void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    // Hide the UI Panel
    void HideUI()
    {
        uiPanel.SetActive(false);
    }
}
