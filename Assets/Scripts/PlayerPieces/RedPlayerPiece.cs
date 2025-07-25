using UnityEngine;
using System.Collections;

public class RedPlayerPiece : PlayerPiece
{
    RollingDice redHomeRollingDice;
    void Start()
    {
        redHomeRollingDice = GetComponentInParent<RedHome>().rollingDice;
    }
    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gm.rollingDice == redHomeRollingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove)
                {
                    MakePlayerReadyToMove(pathParent.RedPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.rollingDice == redHomeRollingDice && isReady && GameManager.gm.canPlayerMove)
            {
                GameManager.gm.canPlayerMove = false;
                MovePlayer(pathParent.RedPathPoint);
            }

        }
    }


}
