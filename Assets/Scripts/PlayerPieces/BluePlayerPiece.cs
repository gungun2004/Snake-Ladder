using UnityEngine;
using System.Collections; // Required for IEnumerator

public class BluePlayerPiece : PlayerPiece
{
    void Start()
    {
       
    }

    public void OnMouseDown()
    {
        if (!isReady)
        {
            MakePlayerReadyToMove(pathParent.BluePathPoint);
            return;
        }

        MovePlayer(pathParent.BluePathPoint);
    }
}
