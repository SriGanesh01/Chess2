using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RandomBot : MonoBehaviour
{
    public GlobalConstants globalConstants;

    public List<Vector3> ListOfMoves;


    private void Update() {
        // MakeRandomMove();
    }
    void DoStuff()
    {
        if (globalConstants.IsGameOver == false)
        {
            // MakeRandomMove();
        }
    }

    void MakeRandomMove()
    {
        // globalConstants.ValidateAndMove(globalConstants.randomPiece, globalConstants.randomLocation);
        globalConstants.IsWhitesTurn = !globalConstants.IsWhitesTurn;
    }
}
