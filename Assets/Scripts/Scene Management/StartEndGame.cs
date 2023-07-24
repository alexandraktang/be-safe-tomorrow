using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndGame : MonoBehaviour
{
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    public void OnStartButtonClick()
    {
        SceneManager.LoadSceneAsync(sceneIndex + 1);
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadSceneAsync(0);
        Destroy(GameObject.Find("bg music obj"));
    }
}
