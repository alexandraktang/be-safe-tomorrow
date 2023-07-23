using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 mousePosition;
    SpriteRenderer draggableObjectSpriteRenderer;
    Color tempColor;
    
    // Start is called before the first frame update
    void Start()
    {
        draggableObjectSpriteRenderer = this.GetComponent<SpriteRenderer>();
        tempColor = draggableObjectSpriteRenderer.color;
        tempColor.a = .6f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePosition();
    }

    void OnMouseDrag()
    {
        if (!this.gameObject.GetComponentInParent<ActionManager>().animPlaying) 
        {
            draggableObjectSpriteRenderer.color = tempColor;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }

    void OnMouseUp()
    {
        if (!this.gameObject.GetComponentInParent<ActionManager>().animPlaying) 
        {
            this.gameObject.SetActive(false);
        }
    }
}
