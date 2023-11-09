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
}
