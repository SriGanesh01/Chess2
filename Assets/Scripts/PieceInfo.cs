using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceInfo : MonoBehaviour
{
    public GlobalConstants globalConstants;
    public string pieceColour;
    public string pieceType;
    public Vector3 piecePosition;
    public GameObject itself;

    private void Start() {
        globalConstants = FindObjectOfType<GlobalConstants>();
        piecePosition = transform.position;
        itself = this.gameObject;
    }

    public void OnDestroy() {
        if (pieceType == "King")
        {
            globalConstants.IsGameOver = true;
        }
    }
}
