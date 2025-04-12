using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPieces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        // Debug.Log("Mouse Entered Piece: " + gameObject.name);
        // Debug.Log("Mouse Entered Piece: " + gameObject.transform.position);
    }

    /// <summary>
    /// OnMouseDrag is called when the user has clicked on a GUIElement or Collider
    /// and is still holding down the mouse.
    /// </summary>
    void OnMouseDrag()
    {
        Debug.Log("Dragging" + gameObject.name);
        Vector3 mousePosition = Input.mousePosition;
        float z = transform.position.z;
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(screenPoint.x, screenPoint.y, z);
    }

    void OnMouseUp()
    {
        Debug.Log("Clicked on: " + gameObject.name);
        transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) +0.5f, transform.position.z);
    }
}
