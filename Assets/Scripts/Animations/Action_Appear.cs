using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Appear : MonoBehaviour
{
    [SerializeField] bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateActionObject()
    {
        isActive = true;
    }
}
