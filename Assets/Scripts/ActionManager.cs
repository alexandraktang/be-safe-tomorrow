using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    [SerializeField] GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] SpriteRenderer actionSpriteRenderer;
    [SerializeField] List<Sprite> nextActionIMGs;
    [SerializeField] AudioSource actionSFX;
    [SerializeField] float delayTime;
    [SerializeField] Animator actionAnimator;

    bool swappingIMG = false;
    int actionIMGCounter = 0;

    public bool firstClick = false;
    SpriteRenderer[] childSpriteRenderersList;
    public bool taskComplete = false;
    public bool animPlaying = false;

    GameObject bgMusicObj;
    AudioSource[] bgMusicObjs;
    GameObject introMusicObj;
    GameObject truBGMusicObj;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void Awake()
    {
        if (bgMusicObj == null)
        {
            bgMusicObj = GameObject.Find("bg music obj");
            bgMusicObjs = bgMusicObj.GetComponentsInChildren<AudioSource>(true);
            introMusicObj = bgMusicObjs[0].gameObject;
            truBGMusicObj = bgMusicObjs[1].gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bgMusicObj != null)
        {
            DontDestroyOnLoad(bgMusicObj);
        }
        
        if (taskComplete && introMusicObj.activeInHierarchy)
        {
            introMusicObj.SetActive(false);
            truBGMusicObj.SetActive(true);
        }
        
        if (!firstClick && Input.GetMouseButtonDown(0))
        {
            firstClick = true;
            actionAnimator.SetBool("firstClick", true);
            if (nextActionIMGs.Count <= 0) // plays Alarm sound in waking up scenes
            {
                this.gameObject.GetComponent<AudioSource>().Play();
            }
        }        
        if (Input.GetMouseButtonUp(0) == true && animPlaying == false && swappingIMG == false && actionIMGCounter < nextActionIMGs.Count)
        {
            swappingIMG = true;
            ChangeBubbleSpriteIMG();
            swappingIMG = false;
        }
        else if (Input.GetMouseButtonUp(0) == true && animPlaying == false && swappingIMG == false && actionIMGCounter == nextActionIMGs.Count)
        {
            ActionAnimOut();
        }
    }

    void ChangeBubbleSpriteIMG()
    {
        actionSpriteRenderer.sprite = nextActionIMGs.ElementAt(actionIMGCounter);
        actionIMGCounter++;
        actionSFX.Play();
    }

    void ActionAnimOut()
    {
        taskComplete = true;
        actionAnimator.SetBool("taskComplete", taskComplete);
    }

    public void SetBGSeqActive()
    {
        gameManager.changeBGIMG = true;
    }

    public void SetAnimPlaying()
    {
        childSpriteRenderersList = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        if (childSpriteRenderersList != null)
        {
            foreach (SpriteRenderer sr in childSpriteRenderersList)
            {
                sr.enabled = true;
            }
        }
        animPlaying = true;
    }

    public void SetAnimNotPlaying()
    {
        animPlaying = false;
    }
}
