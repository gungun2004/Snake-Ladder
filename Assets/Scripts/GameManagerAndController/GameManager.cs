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
        int nextDice;
        if(transferDice)
        {  
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
                if (rollingDice == rollingDiceList[i])
                    {
                        rollingDiceList[i].gameObject.SetActive(false);
                        rollingDiceList[nextDice].gameObject.SetActive(true);
                    }
                }
        }
        canDiceRoll = true;
        transferDice = false;
    }
}
