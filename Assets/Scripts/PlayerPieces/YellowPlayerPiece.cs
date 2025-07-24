using UnityEngine;

public class YellowPlayerPiece : PlayerPiece
{
    public void OnMouseDown()
    {
        if (!isReady)
        {
            MakePlayerReadyToMove(pathParent.YellowPathPoint);
            return;
        }

        MovePlayer(pathParent.YellowPathPoint);
    }
}
