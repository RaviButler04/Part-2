using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandling : MonoBehaviour
{
    public void nextScene()
    {
        //move to next scene
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (CurrentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
