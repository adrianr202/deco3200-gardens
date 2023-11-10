// Responsible for changing scenes in a Unity project. 

// LoadMainScreen(): This method loads the scene with the build index 0 using Unity's SceneManager.
// This scene is the InitialScreen, the starting screen when the user opens the app

// LoadARScreen(): This method loads the scene with the build index 1
// This scene is the main AR Screen, when clicked Enter Gardens

// LoadARDecalScreen(): This method loads the scene with the build index 2
// This scene is the Decal feature, moving to another screen from the main AR screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LoadMainScreen() {
        SceneManager.LoadScene(0);
    }

    public void LoadARScreen() {
        SceneManager.LoadScene(1);
    }

    public void LoadARDecalScreen() {
        SceneManager.LoadScene(2);
    }
}
