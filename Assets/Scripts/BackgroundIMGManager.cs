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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
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
        foreach (Sprite bgIMG in nextBGIMGs)
        {
            yield return new WaitForSeconds(delayTime);
            bgSpriteRenderer.sprite = bgIMG;
        }

        nextSceneArrow.SetActive(true);
        gameManager.bgSequenceComplete = true;
    }
}
