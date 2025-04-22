using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConstants : MonoBehaviour
{
    public int boardSize = 8;
    public bool IsWhitesTurn = true;
    public bool IsGameOver = false;

    public List<Vector3> allValidLocations = new List<Vector3>();
    public List<GameObject> allValidPieces = new List<GameObject>();

    // public List<GameObject> allRobotValidPieces = new List<GameObject>();
    // public List<Vector3> allRobotValidLocations = new List<Vector3>();
    

    public GameObject PiecesPrefab;
    public PieceInfo pieceInfo;
    // public SquareInfo squareInfo;
    // public Pieces Pieces;
    public AllPiecesData allPiecesData;

    public GameObject randomPiece;
    public Vector3 randomLocation;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f); // small delay
        MoveablePiecesUpdated();
        
    }

    IEnumerator MakeRandomMove()
    {
        yield return new WaitForSeconds(0.1f);
        ValidateAndMoveBot(randomPiece, randomPiece.transform.position, randomLocation);
        MoveablePiecesUpdated();
        CalculateAllValidLocationsAndStore(randomPiece, allValidLocations);
    }

    public void Update() {
        GetRandomMoveablePiece();
        GetRandomValidLocation(randomPiece);
        StartCoroutine(MakeRandomMove());
    }

    public void GetRandomMoveablePiece()
    {
        if (allValidPieces.Count > 0)
        {
            randomPiece = allValidPieces[Random.Range(0, allValidPieces.Count)];
        }
    }

    public void GetRandomValidLocation(GameObject piece)
    {
        List<Vector3> validLocations = new List<Vector3>();
        CalculateAllValidLocationsAndStore(piece, validLocations);
        if (validLocations.Count > 0)
        {
            randomLocation = validLocations[Random.Range(0, validLocations.Count)];
            Debug.Log("Random Location: " + randomLocation);
        }
        else
        {
            Debug.Log("No valid locations for the piece");
        }
    }

    public void MoveablePiecesUpdated()
    {
        allValidPieces.Clear();
        foreach (PieceInfo pieces in FindObjectsOfType<PieceInfo>())
        {
            Debug.Log("Piece: " + pieces.gameObject.name + " Position: " + pieces.piecePosition);
            if (HasValidLocationsCheck(pieces.gameObject))
            {
                allValidPieces.Add(pieces.gameObject);
            }
        }
    }

    public bool HasValidLocationsCheck(GameObject SelcPic)
    {
        GameObject selectedPiece = SelcPic;

        foreach (SquareInfo square in FindObjectsOfType<SquareInfo>())
        {
            Vector3 squarePos = square.transform.position;

            if (ValidateBool(selectedPiece, selectedPiece.transform.position, squarePos))
            {
                return true;
            }
            // return false;
        }
        return false;
    }

    public void CalculateAllValidLocationsAndStore(GameObject SelcPic, List<Vector3> Locs)
    {
        Locs.Clear();
        // allValidPieces.Clear();
        GameObject selectedPiece = SelcPic;

        foreach (SquareInfo square in FindObjectsOfType<SquareInfo>())
        {
            Vector3 squarePos = square.transform.position;

            if (ValidateBool(selectedPiece, selectedPiece.transform.position, squarePos))
            {
                Locs.Add(squarePos);
                // return true;
            }
            // return false;
        }
        // return false;
    }


    public bool ValidateBool(GameObject piece, Vector3 oldPosition, Vector3 targPos)
    {
        Vector3 currentPos = piece.transform.position;
        Rules rules = piece.GetComponent<Rules>();
        pieceInfo = piece.GetComponent<PieceInfo>();
        Vector3 targetPosition = targPos;
        bool validMove = true;
        bool isBounded = true;



        float dx = targetPosition.x - oldPosition.x;
        float dy = targetPosition.y - oldPosition.y;

        if (Mathf.Abs(targetPosition.x) <= (boardSize) / 2 && Mathf.Abs(targetPosition.y) <= (boardSize) / 2)
        {
            isBounded = true;
        }
        else
        {
            isBounded = false;
        }

        if (rules.IsWhitePawn())
        {
            bool isCapturing = false;
            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.pieceColour != pieceInfo.pieceColour && other.piecePosition == targetPosition)
                {
                    isCapturing = true;
                    break;
                }
            }

            validMove = (dx == 0 && (dy == 1 || (Mathf.Floor(oldPosition.y) == 1 && dy == 2))) ||
                        (Mathf.Abs(dx) == 1 && dy == 1 && isCapturing);
        }

        else if (rules.IsBlackPawn())
        {
            bool isCapturing = false;
            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.pieceColour != pieceInfo.pieceColour && other.piecePosition == targetPosition)
                {
                    isCapturing = true;
                    break;
                }
            }

            validMove = (dx == 0 && (dy == -1 || (Mathf.Floor(oldPosition.y) == 6 && dy == -2))) ||
                        (Mathf.Abs(dx) == 1 && dy == -1 && isCapturing);
        }

        else if (rules.IsKnight())
        {
            validMove = (Mathf.Abs(dx) == 2 && Mathf.Abs(dy) == 1) || (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 2);
        }
        else if (rules.IsRook())
        {
            validMove = (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
        }
        else if (rules.IsBishop())
        {
            validMove = Mathf.Abs(dx) == Mathf.Abs(dy);
        }
        else if (rules.IsQueen())
        {
            validMove = Mathf.Abs(dx) == Mathf.Abs(dy) || (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
        }
        else if (rules.IsKing())
        {
            validMove = (Mathf.Abs(dx) <= 1 && Mathf.Abs(dy) <= 1 && (dx != 0 || dy != 0));
        }

        if (IsWhitesTurn && pieceInfo.pieceColour == "Black")
        {
            return false;
        }
        if (!IsWhitesTurn && pieceInfo.pieceColour == "White")
        {
            return false;
        }

        if (validMove && isBounded && !IsBlockingPiece(piece, targetPosition))
        {
            foreach (PieceInfo item in FindObjectsOfType<PieceInfo>())
            {
                if (item.piecePosition == targetPosition && item.pieceColour == pieceInfo.pieceColour)
                {
                    return false;
                }
                else if (item.piecePosition == targetPosition && item.pieceColour != pieceInfo.pieceColour)
                {
                    return true;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ValidateAndMoveBot(GameObject piece, Vector3 oldPosition, Vector3 targetPos)
    {
        Vector3 currentPos = piece.transform.position;
        Rules rules = piece.GetComponent<Rules>();
        PieceInfo pieceInfo = piece.GetComponent<PieceInfo>();
        Vector3 targetPosition = targetPos;
        bool validMove = true;
        bool isBounded = true;



        float dx = targetPosition.x - oldPosition.x;
        float dy = targetPosition.y - oldPosition.y;

        if (Mathf.Abs(targetPosition.x) <= (boardSize) / 2 && Mathf.Abs(targetPosition.y) <= (boardSize) / 2)
        {
            isBounded = true;
        }
        else
        {
            isBounded = false;
        }

        if (rules.IsWhitePawn())
        {
            bool isCapturing = false;
            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.pieceColour != pieceInfo.pieceColour && other.piecePosition == targetPosition)
                {
                    isCapturing = true;
                    break;
                }
            }

            validMove = (dx == 0 && (dy == 1 || (Mathf.Floor(oldPosition.y) == 1 && dy == 2))) ||
                        (Mathf.Abs(dx) == 1 && dy == 1 && isCapturing);
        }

        else if (rules.IsBlackPawn())
        {
            bool isCapturing = false;
            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.pieceColour != pieceInfo.pieceColour && other.piecePosition == targetPosition)
                {
                    isCapturing = true;
                    break;
                }
            }

            validMove = (dx == 0 && (dy == -1 || (Mathf.Floor(oldPosition.y) == 6 && dy == -2))) ||
                        (Mathf.Abs(dx) == 1 && dy == -1 && isCapturing);
        }

        else if (rules.IsKnight())
        {
            validMove = (Mathf.Abs(dx) == 2 && Mathf.Abs(dy) == 1) || (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 2);
        }
        else if (rules.IsRook())
        {
            validMove = (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
        }
        else if (rules.IsBishop())
        {
            validMove = Mathf.Abs(dx) == Mathf.Abs(dy);
        }
        else if (rules.IsQueen())
        {
            validMove = Mathf.Abs(dx) == Mathf.Abs(dy) || (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
        }
        else if (rules.IsKing())
        {
            validMove = (Mathf.Abs(dx) <= 1 && Mathf.Abs(dy) <= 1 && (dx != 0 || dy != 0));
        }

        if (IsWhitesTurn && pieceInfo.pieceColour == "Black")
        {
            piece.transform.position = oldPosition;
            return;
        }
        if (!IsWhitesTurn && pieceInfo.pieceColour == "White")
        {
            piece.transform.position = oldPosition;
            return;
        }

        if (validMove && isBounded && !IsBlockingPiece(piece, targetPosition))
        {
            foreach (PieceInfo item in FindObjectsOfType<PieceInfo>())
            {
                if (item.piecePosition == targetPosition && item.pieceColour == pieceInfo.pieceColour)
                {
                    piece.transform.position = oldPosition;
                    return;
                }
                else if (item.piecePosition == targetPosition && item.pieceColour != pieceInfo.pieceColour)
                {
                    Destroy(item.gameObject);
                    allPiecesData.allPieces.Remove(item.gameObject);
                    piece.transform.position = targetPosition;
                    pieceInfo.piecePosition = targetPosition;
                    IsWhitesTurn = !IsWhitesTurn;
                    return;
                }
            }
            piece.transform.position = targetPosition;
            pieceInfo.piecePosition = targetPosition;
            IsWhitesTurn = !IsWhitesTurn;
        }
        else
        {
            piece.transform.position = oldPosition;
        }
    }

    public void ValidateAndMove(GameObject piece, Vector3 oldPosition)
    {
        Vector3 currentPos = piece.transform.position;
        Rules rules = piece.GetComponent<Rules>();
        PieceInfo pieceInfo = piece.GetComponent<PieceInfo>();
        Vector3 targetPosition = new Vector3(Mathf.Floor(currentPos.x) + 0.5f, Mathf.Floor(currentPos.y) + 0.5f, currentPos.z);
        bool validMove = true;
        bool isBounded = true;



        float dx = targetPosition.x - oldPosition.x;
        float dy = targetPosition.y - oldPosition.y;

        if (Mathf.Abs(targetPosition.x) <= (boardSize) / 2 && Mathf.Abs(targetPosition.y) <= (boardSize) / 2)
        {
            isBounded = true;
        }
        else
        {
            isBounded = false;
        }

        if (rules.IsWhitePawn())
        {
            bool isCapturing = false;
            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.pieceColour != pieceInfo.pieceColour && other.piecePosition == targetPosition)
                {
                    isCapturing = true;
                    break;
                }
            }

            validMove = (dx == 0 && (dy == 1 || (Mathf.Floor(oldPosition.y) == 1 && dy == 2))) ||
                        (Mathf.Abs(dx) == 1 && dy == 1 && isCapturing);
        }

        else if (rules.IsBlackPawn())
        {
            bool isCapturing = false;
            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.pieceColour != pieceInfo.pieceColour && other.piecePosition == targetPosition)
                {
                    isCapturing = true;
                    break;
                }
            }

            validMove = (dx == 0 && (dy == -1 || (Mathf.Floor(oldPosition.y) == 6 && dy == -2))) ||
                        (Mathf.Abs(dx) == 1 && dy == -1 && isCapturing);
        }

        else if (rules.IsKnight())
        {
            validMove = (Mathf.Abs(dx) == 2 && Mathf.Abs(dy) == 1) || (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 2);
        }
        else if (rules.IsRook())
        {
            validMove = (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
        }
        else if (rules.IsBishop())
        {
            validMove = Mathf.Abs(dx) == Mathf.Abs(dy);
        }
        else if (rules.IsQueen())
        {
            validMove = Mathf.Abs(dx) == Mathf.Abs(dy) || (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
        }
        else if (rules.IsKing())
        {
            validMove = (Mathf.Abs(dx) <= 1 && Mathf.Abs(dy) <= 1 && (dx != 0 || dy != 0));
        }

        if (IsWhitesTurn && pieceInfo.pieceColour == "Black")
        {
            piece.transform.position = oldPosition;
            return;
        }
        if (!IsWhitesTurn && pieceInfo.pieceColour == "White")
        {
            piece.transform.position = oldPosition;
            return;
        }

        if (validMove && isBounded && !IsBlockingPiece(piece, targetPosition))
        {
            foreach (PieceInfo item in FindObjectsOfType<PieceInfo>())
            {
                if (item.piecePosition == targetPosition && item.pieceColour == pieceInfo.pieceColour)
                {
                    piece.transform.position = oldPosition;
                    return;
                }
                else if (item.piecePosition == targetPosition && item.pieceColour != pieceInfo.pieceColour)
                {
                    Destroy(item.gameObject);
                    allPiecesData.allPieces.Remove(item.gameObject);
                    piece.transform.position = targetPosition;
                    pieceInfo.piecePosition = targetPosition;
                    IsWhitesTurn = !IsWhitesTurn;
                    return;
                }
            }
            piece.transform.position = targetPosition;
            pieceInfo.piecePosition = targetPosition;
            IsWhitesTurn = !IsWhitesTurn;
        }
        else
        {
            piece.transform.position = oldPosition;
        }
    }

    bool IsBlockingPiece(GameObject piece, Vector3 targetPosition)
    {
        Vector3 start = piece.GetComponent<PieceInfo>().piecePosition;
        float dx = targetPosition.x - start.x;
        float dy = targetPosition.y - start.y;

        int stepX = dx == 0 ? 0 : (int)Mathf.Sign(dx);
        int stepY = dy == 0 ? 0 : (int)Mathf.Sign(dy);

        int steps = (int)Mathf.Max(Mathf.Abs(dx), Mathf.Abs(dy));

        if (piece.GetComponent<Rules>().IsKnight()) return false;

        for (int i = 1; i < steps; i++)
        {
            Vector3 checkPos = new Vector3(
                start.x + stepX * i,
                start.y + stepY * i,
                start.z
            );

            foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
            {
                if (other.piecePosition == checkPos)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
