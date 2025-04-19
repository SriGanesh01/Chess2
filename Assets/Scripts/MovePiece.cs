using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public Rules rules;
    public GlobalConstants globalConstants;

    Vector3 oldPosition;
    Vector3 currentPosition;

    void Start()
    {
        globalConstants = FindObjectOfType<GlobalConstants>();
        rules = GetComponent<Rules>();
    }
    void OnMouseEnter()
    {
        // Debug.Log("Mouse Entered Piece: " + gameObject.name);
        // Debug.Log("Mouse Entered Piece: " + gameObject.transform.position);
    }

    private void OnMouseDown()
    {
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
        PieceLogic();
    }

    bool LocationOfEdge(Vector3 position)
    {
        if (Mathf.Abs(position.x) == (globalConstants.boardSize - 1) / 2f || Mathf.Abs(position.y) == (globalConstants.boardSize - 1) / 2f)
        {
            return true;
        }
        return false;
    }

    void PieceLogic()
    {
        if (rules.IsWhitePawn())
        {
            if (
                    (Mathf.Floor(transform.position.y) + 0.5f == oldPosition.y + 1 && Mathf.Floor(transform.position.x) + 0.5f == oldPosition.x ) ||
                    (Mathf.Floor(transform.position.y) + 0.5f == oldPosition.y + 2 && Mathf.Floor(transform.position.x) + 0.5f == oldPosition.x )
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }

        else if (rules.IsBlackPawn())
        {
            if (
                    (Mathf.Floor(transform.position.y) + 0.5f == oldPosition.y - 1 && Mathf.Floor(transform.position.x) + 0.5f == oldPosition.x ) ||
                    (Mathf.Floor(transform.position.y) + 0.5f == oldPosition.y - 2 && Mathf.Floor(transform.position.x) + 0.5f == oldPosition.x )
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }

        else if (rules.IsKnight())
        {
            if (
                    Mathf.Floor(transform.position.y) + 0.5 == oldPosition.y + 2 && ((Mathf.Floor(transform.position.x) + 0.5 == oldPosition.x + 1) || (Mathf.Floor(transform.position.x) + 0.5 == oldPosition.x - 1)) ||
                    Mathf.Floor(transform.position.y) + 0.5 == oldPosition.y - 2 && ((Mathf.Floor(transform.position.x) + 0.5 == oldPosition.x + 1) || (Mathf.Floor(transform.position.x) + 0.5 == oldPosition.x - 1)) ||
                    Mathf.Floor(transform.position.x) + 0.5 == oldPosition.x + 2 && ((Mathf.Floor(transform.position.y) + 0.5 == oldPosition.y + 1) || (Mathf.Floor(transform.position.y) + 0.5 == oldPosition.y - 1)) ||
                    Mathf.Floor(transform.position.x) + 0.5 == oldPosition.x - 2 && ((Mathf.Floor(transform.position.y) + 0.5 == oldPosition.y + 1) || (Mathf.Floor(transform.position.y) + 0.5 == oldPosition.y - 1))
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }

        else if (rules.IsRook())
        {
            if (
                    (Mathf.Floor(transform.position.y) + 0.5f == oldPosition.y && Mathf.Floor(transform.position.x) + 0.5f != oldPosition.x) ||
                    (Mathf.Floor(transform.position.x) + 0.5f == oldPosition.x && Mathf.Floor(transform.position.y) + 0.5f != oldPosition.y)
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }

        else if (rules.IsBishop())
        {
            if (
                    (Mathf.Abs(Mathf.Floor(transform.position.x) + 0.5f - oldPosition.x) == Mathf.Abs(Mathf.Floor(transform.position.y) + 0.5f - oldPosition.y))
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }

        else if (rules.IsQueen())
        {
            if (
                    (Mathf.Abs(Mathf.Floor(transform.position.x) + 0.5f - oldPosition.x) == Mathf.Abs(Mathf.Floor(transform.position.y) + 0.5f - oldPosition.y)) ||
                    (Mathf.Floor(transform.position.y) + 0.5f == oldPosition.y && Mathf.Floor(transform.position.x) + 0.5f != oldPosition.x) ||
                    (Mathf.Floor(transform.position.x) + 0.5f == oldPosition.x && Mathf.Floor(transform.position.y) + 0.5f != oldPosition.y)
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }
        
        else if (rules.IsKing())
        {
            if (
                    (Mathf.Abs(Mathf.Floor(transform.position.x) + 0.5f - oldPosition.x) == 1 && Mathf.Abs(Mathf.Floor(transform.position.y) + 0.5f - oldPosition.y) == 0) ||
                    (Mathf.Abs(Mathf.Floor(transform.position.x) + 0.5f - oldPosition.x) == 0 && Mathf.Abs(Mathf.Floor(transform.position.y) + 0.5f - oldPosition.y) == 1)
                )
            {
                transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = oldPosition;
            }
        }
        else
        {
            transform.position = new Vector3(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f, transform.position.z);
        }
    }
}
