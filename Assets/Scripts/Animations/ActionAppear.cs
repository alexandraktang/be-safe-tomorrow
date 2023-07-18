using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAppear : MonoBehaviour
{
    [SerializeField] bool isActive = false;
    [SerializeField] float delay;
    [SerializeField] GameObject objectToActivate;
    [SerializeField] GameObject alarmSpriteObject;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateActionObject(delay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActivateActionObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToActivate.SetActive(true);
        isActive = true;
    }

    public void ActivateAlarmSprite()
    {
        alarmSpriteObject.SetActive(true);
    }
}
