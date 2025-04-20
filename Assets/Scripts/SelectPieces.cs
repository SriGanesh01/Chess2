using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPieces : MonoBehaviour
{
    public GlobalConstants globalConstants;
    public bool isSelected = true;

    private void Start() {
        globalConstants = FindObjectOfType<GlobalConstants>();
    }
    void OnMouseDown()
    {
        globalConstants.PiecesPrefab = gameObject;
        isSelected = true;
    }

    void OnMouseUp()
    {
        isSelected = false;
    }
}
