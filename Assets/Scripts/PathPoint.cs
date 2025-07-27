using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PathPoint : MonoBehaviour
{
    public PathObjectPoint pathObjectPoint;
    public  List<PlayerPiece> playerPieceList = new List<PlayerPiece>();
    PathPoint[] pathPointToMoveOn_;

    void Start()
    {
        pathObjectPoint = GetComponentInParent<PathObjectPoint>();
    }

    public bool AddPlayerPiece(PlayerPiece playerPiece_)
    {
        if (this.name == "CommonPathPoint")
        {
            playerPieceList.Add(playerPiece_);
            complete(playerPiece_);
            return false;

        }
        if (!pathObjectPoint.SafePoint.Contains(this)) 
        {
            if (playerPieceList.Count == 1)
            {
                string prePlayerPieceName = playerPieceList[0].name;
                string currentPlayerPieceName = playerPiece_.name;
                currentPlayerPieceName = currentPlayerPieceName.Substring(0, currentPlayerPieceName.Length - 4);
                if (!prePlayerPieceName.Contains(currentPlayerPieceName))
                {
                    playerPieceList[0].isReady = false;

                    StartCoroutine(reverOnStart(playerPieceList[0]));

                    playerPieceList[0].numberOfStepsAlreadyMove = 0;
                    RemovePlayerPiece(playerPieceList[0]);
                    playerPieceList.Add(playerPiece_);
                    return false;
                }
            }
        }
        addPlayer(playerPiece_);
        return true;
    }
    IEnumerator reverOnStart(PlayerPiece playerPiece_)
    {
        if(playerPiece_.name.Contains("blue")){GameManager.gm.blueOutPlayer -= 1;pathPointToMoveOn_ = pathObjectPoint.BluePathPoint;}
        else if (playerPiece_.name.Contains("Red")){GameManager.gm.redOutPlayer -= 1; pathPointToMoveOn_ = pathObjectPoint.RedPathPoint;}
        else if (playerPiece_.name.Contains("Green")){GameManager.gm.greenOutPlayer -= 1; pathPointToMoveOn_ = pathObjectPoint.GreenPathPoint;}
        else{GameManager.gm.yellowOutPlayer -= 1; pathPointToMoveOn_ = pathObjectPoint.YellowPathPoint;}

        for(int i=playerPiece_.numberOfStepsAlreadyMove-1;i>=0;i--)
        {
            playerPiece_.transform.position = pathPointToMoveOn_[i].transform.position;
            yield return new WaitForSeconds(0.03f);
        }

        playerPiece_.transform.position = pathObjectPoint.BasePoint[BasePointPosition(playerPiece_.name)].transform.position;
    }
    int BasePointPosition(string name)
    {
        for(int i=0;i<pathObjectPoint.BasePoint.Length;i++)
        {
            if (pathObjectPoint.BasePoint[i].name==name)
            {
                return i;
            }
        }
        return -1;
    }
    void complete(PlayerPiece playerPiece_)
    {
        int totalCompletePlayers;
        if (playerPiece_.name.Contains("blue")) { GameManager.gm.blueOutPlayer -= 1; totalCompletePlayers=GameManager.gm.blueCompletePlayer += 1; }
        else if (playerPiece_.name.Contains("Red")) { GameManager.gm.redOutPlayer -= 1; totalCompletePlayers= GameManager.gm.redCompletePlayer += 1; }
        else if (playerPiece_.name.Contains("Green")) { GameManager.gm.greenOutPlayer -= 1; totalCompletePlayers= GameManager.gm.greenCompletePlayer += 1; }
        else { GameManager.gm.yellowOutPlayer -= 1; totalCompletePlayers= GameManager.gm.yellowCompletePlayer += 1; }
        if(totalCompletePlayers==4)
        {
            //celebration for completing 
        }
    }
    void addPlayer(PlayerPiece playerPiece_)
    {
        playerPieceList.Add(playerPiece_);
        RescaleandRepositioningAllPlayerPiece();
    }
    public void RemovePlayerPiece(PlayerPiece  playerPiece_)
    {
       if(playerPieceList.Contains(playerPiece_))
       {
           playerPieceList.Remove(playerPiece_);
           RescaleandRepositioningAllPlayerPiece();
       }
    }

    public void RescaleandRepositioningAllPlayerPiece()
    {
        int plsCount = playerPieceList.Count;
        if (plsCount == 0) return;

        bool isOdd = (plsCount / 2) == 0 ?false :true;

        int extent = plsCount / 2;
        int counter = 0;
        int spriteLayer = 0;
        if (isOdd)
        {
            for (int i = -extent; i <= extent; i++)
            {
                playerPieceList[counter].transform.localScale = new Vector3(pathObjectPoint.scales[plsCount - 1], pathObjectPoint.scales[plsCount - 1], 1f);

                playerPieceList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjectPoint.positionDifference[plsCount - 1]), transform.position.y, 0f);
            }
        }
        else
        {
            for (int i = -extent; i < extent; i++) {

                playerPieceList[counter].transform.localScale = new Vector3(pathObjectPoint.scales[plsCount - 1], pathObjectPoint.scales[plsCount - 1], 1f);

                playerPieceList[counter].transform.position = new Vector3(transform.position.x + (i * pathObjectPoint.positionDifference[plsCount - 1]), transform.position.y, 0f);
            }
        
        }

        for (int i = 0; i < playerPieceList.Count; i++)
        {
            playerPieceList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = spriteLayer++;

        }
    }

}
