using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] int sceneLoadIndex;
    [SerializeField] int sceneUnloadIndex;
    bool loaded;

    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }
    
    void Awake()
    {
        
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
            AsyncOperation load = SceneManager.LoadSceneAsync(sceneLoadIndex, LoadSceneMode.Additive);
            loaded = true;
            SceneManager.UnloadSceneAsync(sceneUnloadIndex);
        }
    }
}
