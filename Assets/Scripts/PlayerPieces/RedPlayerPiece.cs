using UnityEngine;
using System.Collections;

public class RedPlayerPiece : PlayerPiece
{
    public void OnMouseDown()
    {
        if (!isReady)
        {
            MakePlayerReadyToMove(pathParent.RedPathPoint);
            return;
        }

        MovePlayer(pathParent.RedPathPoint);
    }


    
}
