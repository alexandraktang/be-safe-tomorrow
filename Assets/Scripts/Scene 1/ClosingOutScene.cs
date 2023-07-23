using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosingOutScene : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    [SerializeField] AudioSource exitAudio;

    [SerializeField] GameManager gameManager;
    [SerializeField] SpriteRenderer sceneBGSpriteRenderer;
    [SerializeField] Sprite bg2;
    [SerializeField] Sprite bg3;
    public bool bgSequenceComplete = false; 
    [SerializeField] GameObject nextSceneArrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        allAudioSources = FindObjectsOfType<AudioSource>() as AudioSource[];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseOutScene()
    {
        StopAllAudio();
        StartExitAudio();
        StartCoroutine(StartImageSequence());
    }

    void StopAllAudio() 
    {
        foreach (AudioSource audElem in allAudioSources) 
        {
            audElem.Stop();
        }
    }

    void StartExitAudio()
    {
        exitAudio.gameObject.SetActive(true);
    }

    IEnumerator StartImageSequence()
    {
        yield return new WaitForSeconds(3f);
        sceneBGSpriteRenderer.sprite = bg2;
        yield return new WaitForSeconds(3f);
        sceneBGSpriteRenderer.sprite = bg3;
        yield return new WaitForSeconds(3f);   

        nextSceneArrow.SetActive(true);
        gameManager.bgSequenceComplete = true;
    }
}

