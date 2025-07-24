using UnityEngine;
using System.Collections;

public class GreenPlayerPiece : PlayerPiece
{
    public void OnMouseDown()
    {
        if (!isReady)
        {
            MakePlayerReadyToMove(pathParent.GreenPathPoint);
            return;
        }

        MovePlayer(pathParent.GreenPathPoint);
    }
}