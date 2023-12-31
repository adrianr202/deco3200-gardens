//  Code sourced from Niantic Lightship (2022), added HitTestButton and input events from original source.

// <Summary>
// Perform hit tests based on user input in an AR scene. 
// When a screen touch is detected or the designated button is clicked, it performs a hit test from the center of the screen. 
// If a valid hit test result is found, it spawns a designated game object at the hit location.

// Public Inputs:
// Camera: A reference to the camera used to render the scene. It's used to get the center of the screen for hit testing.

// HitTestType: The types of hit test results to filter against when performing a hit test linked to existing planes.

// PlacementObjectPf: The object that will be placed in the scene when a valid hit test result is found.

// HitTestButton: A public button field that triggers the hit test when clicked.

// <Summary>

// Copyright 2022 Niantic, Inc. All Rights Reserved.

using System.Collections.Generic;

using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.External;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Utilities.Input.Legacy;

using UnityEngine;
using UnityEngine.UI;

namespace Niantic.ARDKExamples.Helpers
{
  //! A helper class that demonstrates hit tests based on user input
  /// <summary>
  /// A sample class that can be added to a scene and takes user input in the form of a screen touch.
  ///   A hit test is run from that location. If a plane is found, spawn a game object at the
  ///   hit location.
  /// </summary>
  public class ARHitTester: MonoBehaviour
  {
    /// The camera used to render the scene. Used to get the center of the screen.
    public Camera Camera;

    /// The types of hit test results to filter against when performing a hit test.
    [EnumFlagAttribute]
    public ARHitTestResultType HitTestType = ARHitTestResultType.ExistingPlane;

    /// The object we will place when we get a valid hit test result!
    public GameObject PlacementObjectPf;

    // Add a public Button field that will trigger the hit test
    public Button HitTestButton;

    /// A list of placed game objects to be destroyed in the OnDestroy method.
    private List<GameObject> _placedObjects = new List<GameObject>();

    /// Internal reference to the session, used to get the current frame to hit test against.
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

    public void PerformHitTest()
    {

      var viewportWidth = GetComponent<Camera>().pixelWidth;
      var viewportHeight = GetComponent<Camera>().pixelHeight;
      
      // Debug.Log("Button clicked."); // Add this line for debugging
      if (_session == null)
      {
        return;
      }

      // Replace touch input logic with a hit test from the center of the screen
      var screenCenter = new Vector2(viewportWidth / 2f, viewportHeight / 2f);

      var currentFrame = _session.CurrentFrame;
      if (currentFrame == null)
      {
        return;
      }

      var results = currentFrame.HitTest
      (
        Camera.pixelWidth,
        Camera.pixelHeight,
        screenCenter,
        HitTestType
      );

      int count = results.Count;
      // Debug.Log("Hit test results: " + count);

      if (count <= 0)
      {
        return;
      }

      // Get the closest result
      var result = results[0];

      var hitPosition = result.WorldTransform.ToPosition();

      _placedObjects.Add(Instantiate(PlacementObjectPf, hitPosition, Quaternion.identity));

      var anchor = result.Anchor;
      Debug.LogFormat
      (
        "Spawning cube at {0} (anchor: {1})",
        hitPosition.ToString("F4"),
        anchor == null
          ? "none"
          : anchor.AnchorType + " " + anchor.Identifier
      );
    }
  }

    // private void Update()
    // {
    //   if (_session == null)
    //   {
    //     return;
    //   }

    //   if (PlatformAgnosticInput.touchCount <= 0)
    //   {
    //     return;
    //   }

    //   var touch = PlatformAgnosticInput.GetTouch(0);
    //   if (touch.phase == TouchPhase.Began)
    //   {
    //     TouchBegan(touch);
    //   }
    // }

  //   private void TouchBegan(Touch touch)
  //   {
  //     var currentFrame = _session.CurrentFrame;
  //     if (currentFrame == null)
  //     {
  //       return;
  //     }
      
  //     if(touch.IsTouchOverUIObject())
  //       return;

  //     var results = currentFrame.HitTest
  //     (
  //       Camera.pixelWidth,
  //       Camera.pixelHeight,
  //       touch.position,
  //       HitTestType
  //     );

  //     int count = results.Count;
  //     Debug.Log("Hit test results: " + count);

  //     if (count <= 0)
  //       return;

  //     // Get the closest result
  //     var result = results[0];

  //     var hitPosition = result.WorldTransform.ToPosition();

  //     _placedObjects.Add(Instantiate(PlacementObjectPf, hitPosition, Quaternion.identity));
      
  //     var anchor = result.Anchor;
  //     Debug.LogFormat
  //     (
  //       "Spawning cube at {0} (anchor: {1})",
  //       hitPosition.ToString("F4"),
  //       anchor == null
  //         ? "none"
  //         : anchor.AnchorType + " " + anchor.Identifier
  //     );
  //   }
  // }
}
