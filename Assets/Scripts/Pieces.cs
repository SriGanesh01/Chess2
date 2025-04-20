using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    public GameObject whitePawn;
    public GameObject whiteRook;
    public GameObject whiteKnight;
    public GameObject whiteBishop;
    public GameObject whiteQueen;
    public GameObject whiteKing;

    public GameObject blackPawn;
    public GameObject blackRook;
    public GameObject blackKnight;
    public GameObject blackBishop;
    public GameObject blackQueen;
    public GameObject blackKing;

    public GameObject Circle;
    public GameObject moveables;

    public BoardUI boardUI;
    public AllPiecesData allPiecesData;

    private void Start() {
        allPiecesData = FindObjectOfType<AllPiecesData>();
    }
    
    public void WPawn(Vector3 pos)
    {
        Instantiate(whitePawn, pos, Quaternion.identity);
        whitePawn.tag = "Pieces";
        allPiecesData.allPieces.Add(whitePawn);
        // allPiecesData.allPiecesData.Add(whitePawn, pos);
        if (whitePawn.GetComponent<SelectPieces>() == null)
        {
            whitePawn.AddComponent<SelectPieces>();
        }

        if (whitePawn.GetComponent<PieceInfo>() == null)
        {
            whitePawn.AddComponent<PieceInfo>();
            whitePawn.GetComponent<PieceInfo>().pieceColour = "White";
            whitePawn.GetComponent<PieceInfo>().pieceType = "Pawn";
        }

        if (whitePawn.GetComponent<MovePiece>() == null)
        {
            whitePawn.AddComponent<MovePiece>();
        }

        if (whitePawn.GetComponent<Rules>() == null)
        {
            whitePawn.AddComponent<Rules>();
        }
    }

    public void WRook(Vector3 pos)
    {
        Instantiate(whiteRook, pos, Quaternion.identity);
        whiteRook.tag = "Pieces";
        allPiecesData.allPieces.Add(whiteRook);
        // allPiecesData.allPiecesData.Add(whiteRook, pos);
        if (whiteRook.GetComponent<SelectPieces>() == null)
        {
            whiteRook.AddComponent<SelectPieces>();
        }

        if (whiteRook.GetComponent<PieceInfo>() == null)
        {
            whiteRook.AddComponent<PieceInfo>();
            whiteRook.GetComponent<PieceInfo>().pieceColour = "White";
            whiteRook.GetComponent<PieceInfo>().pieceType = "Rook";
        }

        if (whiteRook.GetComponent<MovePiece>() == null)
        {
            whiteRook.AddComponent<MovePiece>();
        }

        if (whiteRook.GetComponent<Rules>() == null)
        {
            whiteRook.AddComponent<Rules>();
        }
    }

    public void WKnight(Vector3 pos)
    {
        Instantiate(whiteKnight, pos, Quaternion.identity);
        whiteKnight.tag = "Pieces";
        allPiecesData.allPieces.Add(whiteKnight);
        // allPiecesData.allPiecesData.Add(whiteKnight, pos);
        if (whiteKnight.GetComponent<SelectPieces>() == null)
        {
            whiteKnight.AddComponent<SelectPieces>();
        }

        if (whiteKnight.GetComponent<PieceInfo>() == null)
        {
            whiteKnight.AddComponent<PieceInfo>();
            whiteKnight.GetComponent<PieceInfo>().pieceColour = "White";
            whiteKnight.GetComponent<PieceInfo>().pieceType = "Knight";
        }

        if (whiteKnight.GetComponent<MovePiece>() == null)
        {
            whiteKnight.AddComponent<MovePiece>();
        }

        if (whiteKnight.GetComponent<Rules>() == null)
        {
            whiteKnight.AddComponent<Rules>();
        }
    }

    public void WBishop(Vector3 pos)
    {
        Instantiate(whiteBishop, pos, Quaternion.identity);
        whiteBishop.tag = "Pieces";
        allPiecesData.allPieces.Add(whiteBishop);
        // allPiecesData.allPiecesData.Add(whiteBishop, pos);
        if (whiteBishop.GetComponent<SelectPieces>() == null)
        {
            whiteBishop.AddComponent<SelectPieces>();
        }
        
        if (whiteBishop.GetComponent<PieceInfo>() == null)
        {
            whiteBishop.AddComponent<PieceInfo>();
            whiteBishop.GetComponent<PieceInfo>().pieceColour = "White";
            whiteBishop.GetComponent<PieceInfo>().pieceType = "Bishop";
        }

        if (whiteBishop.GetComponent<MovePiece>() == null)
        {
            whiteBishop.AddComponent<MovePiece>();
        }

        if (whiteBishop.GetComponent<Rules>() == null)
        {
            whiteBishop.AddComponent<Rules>();
        }
    }

    public void WQueen(Vector3 pos)
    {
        Instantiate(whiteQueen, pos, Quaternion.identity);
        whiteQueen.tag = "Pieces";
        allPiecesData.allPieces.Add(whiteQueen);
        // allPiecesData.allPiecesData.Add(whiteQueen, pos);
        if (whiteQueen.GetComponent<SelectPieces>() == null)
        {
            whiteQueen.AddComponent<SelectPieces>();
        }

        if (whiteQueen.GetComponent<PieceInfo>() == null)
        {
            whiteQueen.AddComponent<PieceInfo>();
            whiteQueen.GetComponent<PieceInfo>().pieceColour = "White";
            whiteQueen.GetComponent<PieceInfo>().pieceType = "Queen";
        }

        if (whiteQueen.GetComponent<MovePiece>() == null)
        {
            whiteQueen.AddComponent<MovePiece>();
        }

        if (whiteQueen.GetComponent<Rules>() == null)
        {
            whiteQueen.AddComponent<Rules>();
        }
    }

    public void WKing(Vector3 pos)
    {
        Instantiate(whiteKing, pos, Quaternion.identity);
        whiteKing.tag = "Pieces";
        allPiecesData.allPieces.Add(whiteKing);
        // allPiecesData.allPiecesData.Add(whiteKing, pos);
        if (whiteKing.GetComponent<SelectPieces>() == null)
        {
            whiteKing.AddComponent<SelectPieces>();
        }

        if (whiteKing.GetComponent<PieceInfo>() == null)
        {
            whiteKing.AddComponent<PieceInfo>();
            whiteKing.GetComponent<PieceInfo>().pieceColour = "White";
            whiteKing.GetComponent<PieceInfo>().pieceType = "King";
        }

        if (whiteKing.GetComponent<MovePiece>() == null)
        {
            whiteKing.AddComponent<MovePiece>();
        }

        if (whiteKing.GetComponent<Rules>() == null)
        {
            whiteKing.AddComponent<Rules>();
        }
    }

    public void BPawn(Vector3 pos)
    {
        Instantiate(blackPawn, pos, Quaternion.identity);
        blackPawn.tag = "Pieces";
        allPiecesData.allPieces.Add(blackPawn);
        // allPiecesData.allPiecesData.Add(blackPawn, pos);
        if (blackPawn.GetComponent<SelectPieces>() == null)
        {
            blackPawn.AddComponent<SelectPieces>();
        }

        if (blackPawn.GetComponent<PieceInfo>() == null)
        {
            blackPawn.AddComponent<PieceInfo>();
            blackPawn.GetComponent<PieceInfo>().pieceColour = "Black";
            blackPawn.GetComponent<PieceInfo>().pieceType = "Pawn";
        }

        if (blackPawn.GetComponent<MovePiece>() == null)
        {
            blackPawn.AddComponent<MovePiece>();
        }

        if (blackPawn.GetComponent<Rules>() == null)
        {
            blackPawn.AddComponent<Rules>();
        }
    }

    public void BRook(Vector3 pos)
    {
        Instantiate(blackRook, pos, Quaternion.identity);
        blackRook.tag = "Pieces";
        allPiecesData.allPieces.Add(blackRook);
        // allPiecesData.allPiecesData.Add(blackRook, pos);
        if (blackRook.GetComponent<SelectPieces>() == null)
        {
            blackRook.AddComponent<SelectPieces>();
        }

        if (blackRook.GetComponent<PieceInfo>() == null)
        {
            blackRook.AddComponent<PieceInfo>();
            blackRook.GetComponent<PieceInfo>().pieceColour = "Black";
            blackRook.GetComponent<PieceInfo>().pieceType = "Rook";
        }

        if (blackRook.GetComponent<MovePiece>() == null)
        {
            blackRook.AddComponent<MovePiece>();
        }

        if (blackRook.GetComponent<Rules>() == null)
        {
            blackRook.AddComponent<Rules>();
        }
    }

    public void BKnight(Vector3 pos)
    {
        Instantiate(blackKnight, pos, Quaternion.identity);
        blackKnight.tag = "Pieces";
        allPiecesData.allPieces.Add(blackKnight);
        // allPiecesData.allPiecesData.Add(blackKnight, pos);
        if (blackKnight.GetComponent<SelectPieces>() == null)
        {
            blackKnight.AddComponent<SelectPieces>();
        }

        if (blackKnight.GetComponent<PieceInfo>() == null)
        {
            blackKnight.AddComponent<PieceInfo>();
            blackKnight.GetComponent<PieceInfo>().pieceColour = "Black";
            blackKnight.GetComponent<PieceInfo>().pieceType = "Knight";
        }

        if (blackKnight.GetComponent<MovePiece>() == null)
        {
            blackKnight.AddComponent<MovePiece>();
        }

        if (blackKnight.GetComponent<Rules>() == null)
        {
            blackKnight.AddComponent<Rules>();
        }
    }

    public void BBishop(Vector3 pos)
    {
        Instantiate(blackBishop, pos, Quaternion.identity);
        blackBishop.tag = "Pieces";
        allPiecesData.allPieces.Add(blackBishop);
        // allPiecesData.allPiecesData.Add(blackBishop, pos);
        if (blackBishop.GetComponent<SelectPieces>() == null)
        {
            blackBishop.AddComponent<SelectPieces>();
        }

        if (blackBishop.GetComponent<PieceInfo>() == null)
        {
            blackBishop.AddComponent<PieceInfo>();
            blackBishop.GetComponent<PieceInfo>().pieceColour = "Black";
            blackBishop.GetComponent<PieceInfo>().pieceType = "Bishop";
        }

        if (blackBishop.GetComponent<MovePiece>() == null)
        {
            blackBishop.AddComponent<MovePiece>();
        }

        if (blackBishop.GetComponent<Rules>() == null)
        {
            blackBishop.AddComponent<Rules>();
        }
    }

    public void BQueen(Vector3 pos)
    {
        Instantiate(blackQueen, pos, Quaternion.identity);
        blackQueen.tag = "Pieces";
        allPiecesData.allPieces.Add(blackQueen);
        // allPiecesData.allPiecesData.Add(blackQueen, pos);
        if (blackQueen.GetComponent<SelectPieces>() == null)
        {
            blackQueen.AddComponent<SelectPieces>();
        }

        if (blackQueen.GetComponent<PieceInfo>() == null)
        {
            blackQueen.AddComponent<PieceInfo>();
            blackQueen.GetComponent<PieceInfo>().pieceColour = "Black";
            blackQueen.GetComponent<PieceInfo>().pieceType = "Queen";
        }

        if (blackQueen.GetComponent<MovePiece>() == null)
        {
            blackQueen.AddComponent<MovePiece>();
        }

        if (blackQueen.GetComponent<Rules>() == null)
        {
            blackQueen.AddComponent<Rules>();
        }
    }

    public void BKing(Vector3 pos)
    {
        Instantiate(blackKing, pos, Quaternion.identity);
        blackKing.tag = "Pieces";
        allPiecesData.allPieces.Add(blackKing);
        // allPiecesData.allPiecesData.Add(blackKing, pos);
        if (blackKing.GetComponent<SelectPieces>() == null)
        {
            blackKing.AddComponent<SelectPieces>();
        }

        if (blackKing.GetComponent<PieceInfo>() == null)
        {
            blackKing.AddComponent<PieceInfo>();
            blackKing.GetComponent<PieceInfo>().pieceColour = "Black";
            blackKing.GetComponent<PieceInfo>().pieceType = "King";
        }

        if (blackKing.GetComponent<MovePiece>() == null)
        {
            blackKing.AddComponent<MovePiece>();
        }

        if (blackKing.GetComponent<Rules>() == null)
        {
            blackKing.AddComponent<Rules>();
        }
    }

    // void Start() {
    //     sr = Circle.GetComponent<SpriteRenderer>();
    // }

    public void Moveables(Vector3 pos)
    {
        GameObject moveable = Instantiate(Circle, pos, Quaternion.identity);
        moveable.transform.parent = moveables.transform;

    }

    public void DestroyMoveables()
    {
        foreach (Transform child in moveables.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
