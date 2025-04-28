using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public Rules rules;
    public GlobalConstants globalConstants;

    private Vector3 oldPosition;

    void Start()
    {
        globalConstants = FindObjectOfType<GlobalConstants>();
        rules = GetComponent<Rules>();
    }

    private void OnMouseDown()
    {
        if (globalConstants.IsGameOver) return;

        PieceInfo pieceInfo = GetComponent<PieceInfo>();
        if ((pieceInfo.pieceColour == "White" && !globalConstants.IsWhitesTurn) ||
            (pieceInfo.pieceColour == "Black" && globalConstants.IsWhitesTurn))
        {
            return;
        }

        oldPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (globalConstants.IsGameOver) return;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(worldPosition.x, worldPosition.y, oldPosition.z);
    }

    private void OnMouseUp()
    {
        if (globalConstants.IsGameOver) return;

        Vector3 nearestSquare = FindNearestSquare(transform.position);

        if (globalConstants.IsValidMove(this.gameObject, oldPosition, nearestSquare))
        {
            globalConstants.ValidateAndMove(this.gameObject, oldPosition, nearestSquare);
            globalConstants.UpdateMoveablePieces();
        }
        else
        {
            transform.position = oldPosition;
        }
    }

    Vector3 FindNearestSquare(Vector3 currentPos)
    {
        float closestDistance = float.MaxValue;
        Vector3 closestSquare = oldPosition;

        foreach (SquareInfo square in FindObjectsOfType<SquareInfo>())
        {
            float dist = Vector3.Distance(currentPos, square.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestSquare = square.transform.position;
            }
        }
        return closestSquare;
    }
}
