using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public Rules rules;
    public GlobalConstants globalConstants;

    Vector3 oldPosition;

    void Start()
    {
        globalConstants = FindObjectOfType<GlobalConstants>();
        rules = GetComponent<Rules>();
    }

    public void Update() {
        
    }

    private void OnMouseDown()
    {
        globalConstants.CalculateAllValidLocationsAndStore(this.gameObject, globalConstants.allValidLocations);
        oldPosition = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        float z = transform.position.z;
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(screenPoint.x, screenPoint.y, z);
    }

    void OnMouseUp()
    {
        globalConstants.ValidateAndMove(this.gameObject, oldPosition);
        globalConstants.MoveablePiecesUpdated();
        globalConstants.CalculateAllValidLocationsAndStore(this.gameObject, globalConstants.allValidLocations);
    }
}
