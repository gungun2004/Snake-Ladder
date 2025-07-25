using UnityEngine;
using System.Collections;

public class GreenPlayerPiece : PlayerPiece
{
    RollingDice greenHomeRollingDice;
    void Start()
    {
        greenHomeRollingDice = GetComponentInParent<GreenHome>().rollingDice;
    }
    public void OnMouseDown()
    {
        if (GameManager.gm.rollingDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gm.rollingDice ==greenHomeRollingDice && GameManager.gm.numberOfStepsToMove == 6 && GameManager.gm.canPlayerMove)
                {
                    MakePlayerReadyToMove(pathParent.GreenPathPoint);
                    GameManager.gm.numberOfStepsToMove = 0;
                    return;
                }
            }
            if (GameManager.gm.rollingDice == greenHomeRollingDice && isReady && GameManager.gm.canPlayerMove)
            {
                GameManager.gm.canPlayerMove = false;
                MovePlayer(pathParent.GreenPathPoint);
            }

        }
    }
}