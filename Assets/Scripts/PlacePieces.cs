using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePieces : MonoBehaviour
{
    private string StartingFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

    public Pieces Pieces;

    // Start is called before the first frame update
    void Start()
    {
        if (CheckIfFENIsRightLength())
        {
            PlacePiecesBasedOnFEN();
        }
        else
        {
            Debug.LogError("FEN is not the right length");
        }
    }

    bool CheckIfFENIsRightLength()
    {
        string[] FENParts = StartingFEN.Split(' ');
        string[] FENRows = FENParts[0].Split('/');
        int q = 0;

        for (int i = 0; i < FENRows.Length; i++)
        {
            q = 0;
            for (int j = 0; j < FENRows[i].Length; j++)
            {

                char fenChar = FENRows[i][j];

                switch (fenChar){
                    case 'P':
                    case 'R':
                    case 'N':
                    case 'B':
                    case 'Q':
                    case 'K':
                    case 'p':
                    case 'r':
                    case 'n':
                    case 'b':
                    case 'q':
                    case 'k':
                        q++;
                        break;
                    case '1':
                        q=q+1;
                        break;
                    case '2':
                        q=q+2;
                        break;
                    case '3':
                        q=q+3;
                        break;
                    case '4':
                        q=q+4;
                        break;
                    case '5':
                        q=q+5;
                        break;
                    case '6':
                        q=q+6;
                        break;
                    case '7':
                        q=q+7;
                        break;
                    case '8':
                        q=q+8;
                        break;
                    }
            }
        }
        if (q != 8)
        {
            return false;
        }
        else
        {
            return true;
        }  
    }

    void PlacePiecesBasedOnFEN()
    {
        string[] FENParts = StartingFEN.Split(' ');
        string[] FENRows = FENParts[0].Split('/');

        int file = 0;
        int rows = 7;

        for (int i = 0; i < FENRows.Length; i++)
        {
            for (int j = 0; j < FENRows[i].Length; j++)
            {
                char fenChar = FENRows[i][j];

                Vector3 position = new Vector3(file - 3.5f, rows - 3.5f, 0);
                switch (fenChar)
                {
                    case 'P':
                        Pieces.WPawn(position);
                        break;
                    case 'R':
                        Pieces.WRook(position);
                        break;
                    case 'N':
                        Pieces.WKnight(position);
                        break;
                    case 'B':
                        Pieces.WBishop(position);
                        break;
                    case 'Q':
                        Pieces.WQueen(position);
                        break;
                    case 'K':
                        Pieces.WKing(position);
                        break;
                    case 'p':
                        Pieces.BPawn(position);
                        break;
                    case 'r':
                        Pieces.BRook(position);
                        break;
                    case 'n':
                        Pieces.BKnight(position);
                        break;
                    case 'b':
                        Pieces.BBishop(position);
                        break;
                    case 'q':
                        Pieces.BQueen(position);
                        break;
                    case 'k':
                        Pieces.BKing(position);
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                        file += (int)char.GetNumericValue(fenChar) - 1;
                        break;

                    
                }
                file++;
            }
            file = 0;
            rows--;
        }
    }
}
