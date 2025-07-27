using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int numberOfStepsToMove;
    public RollingDice rollingDice;
    public bool canPlayerMove = true;

    List<PathPoint> PlayersOnPathPointList = new List<PathPoint>();

    public bool canDiceRoll=true;
    public bool transferDice = false;
    public List<RollingDice>rollingDiceList;

    public int blueOutPlayer;
    public int yellowOutPlayer;
    public int greenOutPlayer;
    public int redOutPlayer;

    public int blueCompletePlayer;
    public int yellowCompletePlayer;
    public int greenCompletePlayer;
    public int redCompletePlayer;

    public int totalPlayersCanPlay;
    public List<GameObject> playerHomes;
    public int totalSix;
    public List<PlayerPiece> bluePlayerPieces;
    public List<PlayerPiece> greenPlayerPieces;
    public List<PlayerPiece> redPlayerPieces;
    public List <PlayerPiece> yellowPlayerPieces;
    private void Awake()
    {
        gm = this;
    }
    public void AddPathPoint(PathPoint pathPoint)
    {
       PlayersOnPathPointList.Add(pathPoint);
    }
    public void RemovePathPoint(PathPoint pathPoint)
    {
      if(PlayersOnPathPointList.Contains(pathPoint))

      {
          PlayersOnPathPointList.Remove(pathPoint);
      }
    }
    public void rollingDiceTrasfer()
    {
        
        if (transferDice)
        {
            GameManager.gm.totalSix = 0;
            transferRollingDice();
        }
        else
        {
            if (GameManager.gm.totalPlayersCanPlay == 1)
            {
                if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[2])
                {
                    Invoke("role", 0.6f);
                }
            }
        }
     
        canDiceRoll = true;
        transferDice = false;
    }
    void role()
    {
        rollingDiceList[2].MouseRole();
    }
    void transferRollingDice()
    {
        if (GameManager.gm.totalPlayersCanPlay == 1)
        {
            if (rollingDice == rollingDiceList[0])
            {
                rollingDiceList[0].gameObject.SetActive(false);
                rollingDiceList[2].gameObject.SetActive(true);
                Invoke("role", 0.6f);
            }
            else
            {
                rollingDiceList[2].gameObject.SetActive(false);
                rollingDiceList[0].gameObject.SetActive(true);
            }
        }
        else  if (GameManager.gm.totalPlayersCanPlay == 2)
        {
            if (rollingDice == rollingDiceList[0])
            {
                rollingDiceList[0].gameObject.SetActive(false);
                rollingDiceList[2].gameObject.SetActive(true);
            }
            else
            {
                rollingDiceList[2].gameObject.SetActive(false);
                rollingDiceList[0].gameObject.SetActive(true);
            }
        }
        else if (GameManager.gm.totalPlayersCanPlay == 3)
        {
            int nextDice;
            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    nextDice = 0;
                }
                else
                {
                    nextDice = i + 1;
                }
                i = passOut(i);
                if (rollingDice == rollingDiceList[i])
                {
                    rollingDiceList[i].gameObject.SetActive(false);
                    rollingDiceList[nextDice].gameObject.SetActive(true);
                }
            }
        
    }
        else if (GameManager.gm.totalPlayersCanPlay == 4)
        {
            int nextDice;
            for (int i = 0; i < rollingDiceList.Count; i++)
            {
                if (i == (rollingDiceList.Count - 1))
                {
                    nextDice = 0;
                }
                else
                {
                    nextDice = i + 1;
                }
                i = passOut(i);
                if (rollingDice == rollingDiceList[i])
                {
                    rollingDiceList[i].gameObject.SetActive(false);
                    rollingDiceList[nextDice].gameObject.SetActive(true);
                }
            }
        }
    }
    int passOut(int i)
    {
        if (i == 0)
        {
            if (blueOutPlayer == 4)
            {
                return i + 1;
            }
        
        }
        else if (i == 1)
        {
            if (redOutPlayer == 4)
            {
                return i + 1;
            }

        }
        else if (i == 2)
        {
            if (greenOutPlayer == 4)
            {
                return i + 1;
            }

        }
        else if (i == 3)
        {
            if (yellowOutPlayer == 4)
            {
                return i + 1;
            }

        }
        return i;
    }
}
