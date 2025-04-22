using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceInfo : MonoBehaviour
{
    public string pieceColour;
    public string pieceType;
    public Vector3 piecePosition;
    public GameObject itself;

    private void Start() {
        piecePosition = transform.position;
        itself = this.gameObject;
    }
}
