using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CursorAnimation : MonoBehaviour
{
    float timer = 0.0f;
    float timerDelay = 3.5f;
    float timeScale = 1.0f;

    public bool taskComplete = false;

    [SerializeField] GameObject clickIcon;
    [SerializeField] ActionManager actionManager;
    [SerializeField] Animator cursorAnimator;
    
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
        
        if (actionManager.taskComplete)
        {
            taskComplete = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorAnimator.SetBool("blinkActive", false);
            timer = 0.0f;
        }
        else if (timer > timerDelay)
        {
            cursorAnimator.SetBool("blinkActive", true);
            timer = timer - timerDelay;
            Time.timeScale = timeScale;
        }
    }

    public bool GetTaskComplete()
    {
        return taskComplete;
    }
}
