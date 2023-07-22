using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIMGManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] SpriteRenderer bgSpriteRenderer;
    [SerializeField] List<Sprite> nextBGIMGs;
    [SerializeField] float delayTime;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("changeBGIMG: " + gameManager.changeBGIMG);
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
    }
}
