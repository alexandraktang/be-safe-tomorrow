using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{
    int timesClicked = 0;
    float timer = 0.0f;
    float timerDelay = 5.0f;
    float timeScale = 1.0f;

    public bool taskComplete = false;

    [SerializeField] GameObject clickIcon;
    [SerializeField] Animator alarmAnimController;
    [SerializeField] Animator clickAnimController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timesClicked >= 3)
        {
            taskComplete = true;
            alarmAnimController.SetBool("taskComplete", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            clickAnimController.SetBool("blinkActive", false);
            timer = 0.0f;
            timesClicked++;
        }
        else if (timer > timerDelay)
        {
            clickAnimController.SetBool("blinkActive", true);
            timer = timer - timerDelay;
            Time.timeScale = timeScale;
        }
    }

    public bool GetTaskComplete()
    {
        return taskComplete;
    }
}
