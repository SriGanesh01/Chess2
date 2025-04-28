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

    public GameObject PiecesPrefab;
    public PieceInfo pieceInfo;
    public AllPiecesData allPiecesData;

    private GameObject randomPiece;
    private Vector3 randomLocation;

    private bool botIsMoving = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        UpdateMoveablePieces();
    }

    void Update()
    {
        if (!IsGameOver && !IsWhitesTurn && !botIsMoving)
        {
            StartCoroutine(BotMove());
        }
    }

    IEnumerator BotMove()
    {
        botIsMoving = true;

        yield return new WaitForSeconds(0.3f); // slight delay to "think"

        GetRandomMoveablePiece();
        if (randomPiece == null)
        {
            botIsMoving = false;
            yield break;
        }

        GetRandomValidLocation(randomPiece);
        if (randomLocation == Vector3.zero)
        {
            botIsMoving = false;
            yield break;
        }

        yield return new WaitForSeconds(0.3f);

        // Validate if the move is blocked
        if (IsBlocked(randomPiece, randomPiece.transform.position, randomLocation))
        {
            botIsMoving = false;
            yield break;
        }

        ValidateAndMove(randomPiece, randomPiece.transform.position, randomLocation);

        yield return new WaitForSeconds(0.2f); // wait before next bot move
        UpdateMoveablePieces();

        botIsMoving = false;
    }

    void GetRandomMoveablePiece()
    {
        if (allValidPieces.Count > 0)
            randomPiece = allValidPieces[Random.Range(0, allValidPieces.Count)];
    }

    void GetRandomValidLocation(GameObject piece)
    {
        List<Vector3> validLocations = GetValidLocations(piece);
        if (validLocations.Count > 0)
            randomLocation = validLocations[Random.Range(0, validLocations.Count)];
    }

    public void UpdateMoveablePieces()
    {
        allValidPieces.Clear();
        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (piece.pieceColour == (IsWhitesTurn ? "White" : "Black"))
            {
                if (GetValidLocations(piece.gameObject).Count > 0)
                    allValidPieces.Add(piece.gameObject);
            }
        }
    }

    List<Vector3> GetValidLocations(GameObject piece)
    {
        List<Vector3> validLocs = new List<Vector3>();

        foreach (SquareInfo square in FindObjectsOfType<SquareInfo>())
        {
            Vector3 squarePos = square.transform.position;
            if (IsValidMove(piece, piece.transform.position, squarePos))
                validLocs.Add(squarePos);
        }
        return validLocs;
    }

    public bool IsValidMove(GameObject piece, Vector3 fromPos, Vector3 toPos)
    {
        if (!IsInsideBoard(toPos)) return false;

        PieceInfo pieceInfo = piece.GetComponent<PieceInfo>();

        if ((pieceInfo.pieceColour == "White" && !IsWhitesTurn) ||
            (pieceInfo.pieceColour == "Black" && IsWhitesTurn))
            return false;

        if (pieceInfo.piecePosition == toPos)
            return false; // Can't move to same position

        if (!MoveRules(piece, fromPos, toPos)) return false;
        if (IsBlocked(piece, fromPos, toPos)) return false;

        // Prevent capturing own color
        if (IsFriendlyAt(toPos, pieceInfo.pieceColour)) return false;

        if (WouldCauseCheck(piece, fromPos, toPos)) return false;

        return true;
    }

    bool MoveRules(GameObject piece, Vector3 from, Vector3 to)
    {
        Rules rules = piece.GetComponent<Rules>();
        PieceInfo info = piece.GetComponent<PieceInfo>();

        float dx = Mathf.Round(to.x - from.x);
        float dy = Mathf.Round(to.y - from.y);

        if (rules.IsWhitePawn())
        {
            if (dx == 0) // Moving forward
            {
                if (dy == 1 && !IsPieceAt(to)) return true;
                if (dy == 2 && Mathf.Floor(from.y) == 1 && !IsPieceAt(to) && !IsPieceAt(from + Vector3.up))
                    return true;
            }
            else if (Mathf.Abs(dx) == 1 && dy == 1 && IsEnemyAt(to, info.pieceColour)) // Capturing diagonally
            {
                return true;
            }
            return false;
        }
        if (rules.IsBlackPawn())
        {
            if (dx == 0)
            {
                if (dy == -1 && !IsPieceAt(to)) return true;
                if (dy == -2 && Mathf.Floor(from.y) == 6 && !IsPieceAt(to) && !IsPieceAt(from + Vector3.down))
                    return true;
            }
            else if (Mathf.Abs(dx) == 1 && dy == -1 && IsEnemyAt(to, info.pieceColour))
            {
                return true;
            }
            return false;
        }
        if (rules.IsKnight()) return (Mathf.Abs(dx) == 2 && Mathf.Abs(dy) == 1) || (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 2);
        if (rules.IsRook() || rules.IsBishop() || rules.IsQueen())
        {
            // For linear pieces like Rook, Bishop, Queen, check for blocked paths
            if (IsBlocked(piece, from, to)) return false;
        }
        if (rules.IsKing())
            return Mathf.Abs(dx) <= 1 && Mathf.Abs(dy) <= 1;

        return false;
    }

    bool IsBlocked(GameObject piece, Vector3 from, Vector3 to)
    {
        Debug.Log($"Checking if move is blocked from {from} to {to}");
        Rules rules = piece.GetComponent<Rules>();
        if (rules.IsKnight()) return false; // Knights are never blocked

        Vector3 direction = (to - from).normalized; // Find the direction of the move
        float distance = Mathf.Max(Mathf.Abs(to.x - from.x), Mathf.Abs(to.y - from.y)); // Max distance in either x or y

        // Check every step along the way from the start to the end
        for (int i = 1; i < distance; i++)
        {
            // Move step-by-step along the direction vector
            Vector3 checkPos = from + direction * i;
            checkPos = new Vector3(Mathf.Round(checkPos.x), Mathf.Round(checkPos.y), 0); // Round to grid

            if (IsPieceAt(checkPos)) // Check if there's a piece in the way
            {
                Debug.Log($"Blocked at {checkPos}");
                return true; // Path is blocked
            }
        }
        return false; // No blocking piece found
    }

    bool WouldCauseCheck(GameObject piece, Vector3 from, Vector3 to)
    {
        PieceInfo pieceInfo = piece.GetComponent<PieceInfo>();
        Vector3 originalPos = pieceInfo.piecePosition;
        Vector3 tempPos = piece.transform.position;

        // Simulate move
        piece.transform.position = to;
        pieceInfo.piecePosition = to;

        bool kingInCheck = IsKingUnderAttack(pieceInfo.pieceColour);

        // Undo move
        piece.transform.position = tempPos;
        pieceInfo.piecePosition = originalPos;

        return kingInCheck;
    }

    bool IsKingUnderAttack(string color)
    {
        Vector3 kingPos = Vector3.zero;
        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (piece.pieceColour == color && piece.GetComponent<Rules>().IsKing())
            {
                kingPos = piece.piecePosition;
                break;
            }
        }

        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (piece.pieceColour != color)
            {
                if (IsValidAttack(piece.gameObject, piece.piecePosition, kingPos))
                    return true;
            }
        }
        return false;
    }

    bool IsValidAttack(GameObject piece, Vector3 fromPos, Vector3 toPos)
    {
        if (!MoveRules(piece, fromPos, toPos)) return false;
        if (IsBlocked(piece, fromPos, toPos)) return false;
        if (IsFriendlyAt(toPos, piece.GetComponent<PieceInfo>().pieceColour)) return false;
        return true;
    }

    public void ValidateAndMove(GameObject piece, Vector3 oldPos, Vector3 newPos)
    {
        if (!IsValidMove(piece, oldPos, newPos))
            return;

        foreach (PieceInfo other in FindObjectsOfType<PieceInfo>())
        {
            if (Vector3.Distance(other.piecePosition, newPos) < 0.1f)
            {
                Destroy(other.gameObject);
                allPiecesData.allPieces.Remove(other.gameObject);
                break;
            }
        }

        piece.transform.position = newPos;
        piece.GetComponent<PieceInfo>().piecePosition = newPos;

        if (IsKingUnderAttack(IsWhitesTurn ? "Black" : "White"))
        {
            Debug.Log("Checkmate! Game Over");
            IsGameOver = true;
        }

        IsWhitesTurn = !IsWhitesTurn;
    }

    bool IsCheckmate(string color)
    {
        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (piece.pieceColour == color)
            {
                foreach (SquareInfo square in FindObjectsOfType<SquareInfo>())
                {
                    if (IsValidMove(piece.gameObject, piece.piecePosition, square.transform.position))
                        return false;
                }
            }
        }
        return true;
    }

    bool IsPieceAt(Vector3 position)
    {
        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (Vector3.Distance(piece.piecePosition, position) < 0.1f)
                return true;
        }
        return false;
    }

    bool IsEnemyAt(Vector3 position, string ownColor)
    {
        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (Vector3.Distance(piece.piecePosition, position) < 0.1f && piece.pieceColour != ownColor)
                return true;
        }
        return false;
    }

    bool IsFriendlyAt(Vector3 position, string ownColor)
    {
        foreach (PieceInfo piece in FindObjectsOfType<PieceInfo>())
        {
            if (Vector3.Distance(piece.piecePosition, position) < 0.1f && piece.pieceColour == ownColor)
                return true;
        }
        return false;
    }

    bool IsInsideBoard(Vector3 pos)
    {
        return Mathf.Abs(pos.x) <= (boardSize / 2) && Mathf.Abs(pos.y) <= (boardSize / 2);
    }
}
