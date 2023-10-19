using System.Collections.Generic;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.External;
using Niantic.ARDK.Utilities;
using UnityEngine;

namespace Niantic.ARDKExamples.Helpers
{
    public class ARHitTester : MonoBehaviour
    {
        public Camera ARCamera;
        public GameObject RaycastCamera; // Reference to your custom raycasting GameObject
        [EnumFlagAttribute]
        public ARHitTestResultType HitTestType = ARHitTestResultType.ExistingPlane;
        public GameObject PlacementObjectPf;


        public float rayDistance = 10.0f;


        private List<GameObject> _placedObjects = new List<GameObject>();
        private IARSession _session;

        private void Start()
        {
            ARSessionFactory.SessionInitialized += OnAnyARSessionDidInitialize;
        }

        private void OnAnyARSessionDidInitialize(AnyARSessionInitializedArgs args)
        {
            _session = args.Session;
            _session.Deinitialized += OnSessionDeinitialized;
        }

        private void OnSessionDeinitialized(ARSessionDeinitializedArgs args)
        {
            ClearObjects();
        }

        private void OnDestroy()
        {
            ARSessionFactory.SessionInitialized -= OnAnyARSessionDidInitialize;
            _session = null;
            ClearObjects();
        }

        private void ClearObjects()
        {
            foreach (var placedObject in _placedObjects)
            {
                Destroy(placedObject);
            }

            _placedObjects.Clear();
        }

        private void Update()
        {
            if (_session == null || ARCamera == null)
            {
                return;
            }

            // Get the camera's transform
            Transform cameraTransform = ARCamera.transform;

            // Calculate the end point of the ray based on the camera's forward direction and rayDistance
            Vector3 rayEnd = cameraTransform.position + cameraTransform.forward * rayDistance;

            // Draw the ray in camera space
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * rayDistance, Color.red);

            // Perform raycasting with your custom raycasting GameObject
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, LayerMask.GetMask("ARPlane")))
            {
                HandleRaycastHit(hit);
            }

        }
        
        private void TouchBegan(Touch touch)
{
        // Check if the ARCamera and PlacementObjectPf are set.
        if (ARCamera == null || PlacementObjectPf == null)
        {
            Debug.LogWarning("ARCamera or PlacementObjectPf is not set. Cannot place objects.");
            return;
        }

        // Get the camera's transform
        Transform cameraTransform = ARCamera.transform;

        // Calculate the end point of the ray based on the camera's forward direction and rayDistance
        Vector3 rayEnd = cameraTransform.position + cameraTransform.forward * rayDistance;

        // Create a ray from the camera's position to the ray end
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        
        // Perform a raycast and check if it hits an ARPlane
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, LayerMask.GetMask("ARPlane")))
        {
            // Instantiate the PlacementObjectPf at the hit point and rotation
            GameObject placedObject = Instantiate(PlacementObjectPf, hit.point, Quaternion.identity);
            
            // Optionally, you can do more with the placed object, such as adding scripts or modifying its properties.
            
            // Add the placed object to the list of placed objects for later management.
            _placedObjects.Add(placedObject);
        }
    }


        private void HandleRaycastHit(RaycastHit hit)
        {
            var hitPosition = hit.point;

            _placedObjects.Add(Instantiate(PlacementObjectPf, hitPosition, Quaternion.identity));
        }
    }
    
}
