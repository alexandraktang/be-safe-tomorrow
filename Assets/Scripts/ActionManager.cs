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

    public bool taskComplete = false;

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
        if (Input.GetMouseButtonUp(0) == true && swappingIMG == false && actionIMGCounter < nextActionIMGs.Count)
        {
            swappingIMG = true;
            ChangeBubbleSpriteIMG();
            swappingIMG = false;
        }
        else if (Input.GetMouseButtonUp(0) == true && swappingIMG == false && actionIMGCounter == nextActionIMGs.Count)
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
}
