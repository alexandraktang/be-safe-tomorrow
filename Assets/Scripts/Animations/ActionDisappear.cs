using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDisappear : MonoBehaviour
{
    [SerializeField] bool isActive = false;
    [SerializeField] float delay;
    [SerializeField] GameObject objectToActivate;
    [SerializeField] GameObject alarmSpriteObject;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeactivateActionObject(delay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeactivateActionObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToActivate.SetActive(false);
        isActive = false;
    }

    public void DeactivateAlarmSprite()
    {
        alarmSpriteObject.SetActive(false);
    }
}
