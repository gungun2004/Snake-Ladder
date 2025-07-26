using UnityEngine;
using System.Collections.Generic;

public class PathPoint : MonoBehaviour
{
    public PathObjectPoint pathObjectPoint;
    public  List<PlayerPiece> playerPieceList = new List<PlayerPiece>();

    void Start()
    {
        pathObjectPoint = GetComponentInParent<PathObjectPoint>();
    }
    public void AddPlayerPiece(PlayerPiece playerPiece_)
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
            playerPieceList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteLayer;
            SpriteLayer ++;
        }
    }

}
