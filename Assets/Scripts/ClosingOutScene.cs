using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingOutScene : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] Animator sceneBGAnim;
    
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
        SetReadyForSecond();
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

    public void SetReadyForSecond()
    {
        sceneBGAnim.SetBool("readyForSecond", true);
    }

    public void SetReadyForThird()
    {
        sceneBGAnim.SetBool("readyForThird", true);
    }
}

