using System.Collections;
using System.Collections.Generic;
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

    public void WPawn(Vector3 pos) {
        Instantiate(whitePawn, pos, Quaternion.identity);
    }

    public void WRook(Vector3 pos) {
        Instantiate(whiteRook, pos, Quaternion.identity);
    }

    public void WKnight(Vector3 pos) {
        Instantiate(whiteKnight, pos, Quaternion.identity);
    }

    public void WBishop(Vector3 pos) {
        Instantiate(whiteBishop, pos, Quaternion.identity);
    }

    public void WQueen(Vector3 pos) {
        Instantiate(whiteQueen, pos, Quaternion.identity);
    }

    public void WKing(Vector3 pos) {
        Instantiate(whiteKing, pos, Quaternion.identity);
    }

    public void BPawn(Vector3 pos) {
        Instantiate(blackPawn, pos, Quaternion.identity);
    }

    public void BRook(Vector3 pos) {
        Instantiate(blackRook, pos, Quaternion.identity);
    }

    public void BKnight(Vector3 pos) {
        Instantiate(blackKnight, pos, Quaternion.identity);
    }

    public void BBishop(Vector3 pos) {
        Instantiate(blackBishop, pos, Quaternion.identity);
    }

    public void BQueen(Vector3 pos) {
        Instantiate(blackQueen, pos, Quaternion.identity);
    }

    public void BKing(Vector3 pos) {
        Instantiate(blackKing, pos, Quaternion.identity);
    }
}
