using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    int sceneIndex;
    bool loaded;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    void Update()
    {
        if (gameManager.bgSequenceComplete && Input.GetMouseButtonUp(0))
        {
            LoadAdditiveScene();
        }
    }

    // trigger once BGSequence is done & player clicks
    void LoadAdditiveScene()
    {
        if (!loaded)
        {
            SceneManager.LoadSceneAsync(sceneIndex + 1, LoadSceneMode.Additive);
            loaded = true;
        }
    }
}
