using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{
    int timesClicked = 0;
    float timer = 0.0f;
    float timerDelay = 5.0f;
    float timeScale = 1.0f;

    [SerializeField] Animator clickAnimController;
    [SerializeField] BackgroundIMGManager bgIMGManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!bgIMGManager.bgIMGSequenceOngoing && !bgIMGManager.bgIMGSequenceComplete)
        {
            timer += Time.deltaTime;
        
            if (Input.GetMouseButtonUp(0))
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                clickAnimController.SetBool("blinkActive", false);
                timer = 0.0f;
                timesClicked++;
            }
            else if (timer > timerDelay)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                clickAnimController.SetBool("blinkActive", true);
                timer = timer - timerDelay;
                Time.timeScale = timeScale;
            }
        }
    }
}
