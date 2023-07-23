using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
    [SerializeField] ActionManager actionManager;
    int sceneIndex;
    bool unloaded;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        Debug.Log("sceneIndex: " + sceneIndex);
        if (actionManager.firstClick && Input.GetMouseButtonUp(0))
        {
            UnloadAdditiveScene();
        }
    }
    
    // trigger at first player click for bubble
    void UnloadAdditiveScene()
    {
        if (!unloaded)
        {
            unloaded = true;
            ScenesManager.scenesManager.UnloadScene(sceneIndex);
        }
    }
}
