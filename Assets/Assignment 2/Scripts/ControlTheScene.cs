using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlTheScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        //get the index of the current scene, and move on to next scene (goes around)
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        //load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }
}
