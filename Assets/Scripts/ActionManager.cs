using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject.GetComponentInParent<GameManager>();
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstClick && Input.GetMouseButtonDown(0))
        {
            firstClick = true;
            actionAnimator.SetBool("firstClick", true);
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
