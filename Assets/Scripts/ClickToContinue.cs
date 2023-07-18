using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{
    int timesClicked = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timesClicked >= 3)
        {
            this.gameObject.SetActive(false);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            timesClicked++;
        }
    }
}
