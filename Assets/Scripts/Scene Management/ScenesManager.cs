using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager scenesManager;
    bool gameStart = true;
    
    void Awake()
    {
        if (!gameStart)
        {
            scenesManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;
        }
    }

    public void UnloadScene(int sceneIndex)
    {
        StartCoroutine(Unload(sceneIndex));
    }

    IEnumerator Unload(int sceneIndex)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.UnloadSceneAsync(sceneIndex);
    }
}
