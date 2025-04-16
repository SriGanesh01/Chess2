using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    public PieceInfo pieceInfo;
    public GlobalConstants globalConatants;

    void Start()
    {
        pieceInfo = GetComponent<PieceInfo>();
    }
    public bool IsWhitePawn()
    {
        if (pieceInfo.pieceColour == "White" && pieceInfo.pieceType == "Pawn" )
        {
            return true; 
        }
        return false;
    }

    public bool IsBlackPawn()
    {
        if (pieceInfo.pieceColour == "Black" && pieceInfo.pieceType == "Pawn")
        {
            // IsWhitesTurn = true;
            return true;
        }
        return false;
    }

    public bool IsKnight()
    {
        if (pieceInfo.pieceType == "Knight")
        {
            return true;
        }
        return false;
    }

    public bool IsBishop()
    {
        if (pieceInfo.pieceType == "Bishop")
        {
            return true;
        }
        return false;
    }

    public bool IsRook()
    {
        if (pieceInfo.pieceType == "Rook")
        {
            return true;
        }
        return false;
    }

    public bool IsQueen()
    {
        if (pieceInfo.pieceType == "Queen")
        {
            return true;
        }
        return false;
    }

    public bool IsKing()
    {
        if (pieceInfo.pieceType == "King")
        {
            return true;
        }
        return false;
    }

    public bool IsWhite()
    {
        if (pieceInfo.pieceColour == "White")
        {
            return true;
        }
        return false;
    }

    public bool IsBlack()
    {
        if (pieceInfo.pieceColour == "Black")
        {
            return true;
        }
        return false;
    }

}
