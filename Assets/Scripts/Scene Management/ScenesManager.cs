using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager scenesManager;
    bool gameStart;
    GameObject canvas;
    AsyncOperation firstLoad;
    
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    void Awake()
    {
        if (!gameStart)
        {
            scenesManager = this;
            firstLoad = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            StartCoroutine(TurnOffMMCanvas());
            gameStart = true;
        }
    }

    IEnumerator TurnOffMMCanvas()
    {
        yield return new WaitUntil(() => firstLoad.isDone);
        if (canvas.activeInHierarchy)
        {
            canvas.SetActive(false);
        }
    }
}
