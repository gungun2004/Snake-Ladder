using UnityEngine;
using System.Collections; // Required for IEnumerator

public class BluePlayerPiece : PlayerPiece
{
    RollingDice blueHomeRollingDice;
    void Start()
    {
        blueHomeRollingDice = GetComponentInParent < BlueHome>().rollingDice; 
    }

    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gm.rollingDice == blueHomeRollingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove)
                {
                    GameManager.gm.blueOutPlayer += 1;
                    MakePlayerReadyToMove(pathParent.BluePathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if(GameManager.gm.rollingDice==blueHomeRollingDice && isReady && GameManager.gm.canPlayerMove)
            {
                GameManager.gm.canPlayerMove = false;
                MovePlayer(pathParent.BluePathPoint);
            }
           
        }
    }
}
