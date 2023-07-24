using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIMGManager : MonoBehaviour
{
    [SerializeField] GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] SpriteRenderer bgSpriteRenderer;
    [SerializeField] List<Sprite> nextBGIMGs;
    [SerializeField] float delayTime;
    [SerializeField] GameObject nextSceneArrow;
    public bool bgIMGSequenceOngoing;
    public bool bgIMGSequenceComplete;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
        bgIMGSequenceOngoing = false;
        bgIMGSequenceComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.changeBGIMG == true)
        {
            gameManager.changeBGIMG = false;
            StartCoroutine(StartBGImageSequence());
        }
    }

    IEnumerator StartBGImageSequence()
    {
        bgIMGSequenceOngoing = true;

        foreach (Sprite bgIMG in nextBGIMGs)
        {
            yield return new WaitForSeconds(delayTime);
            bgSpriteRenderer.sprite = bgIMG;
        }

        bgIMGSequenceOngoing = false;
        bgIMGSequenceComplete = true;
        nextSceneArrow.SetActive(true);
        gameManager.bgSequenceComplete = true;
    }
}
