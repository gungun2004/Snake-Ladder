using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int numberOfStepsToMove;
    public RollingDice rollingDice;
    public bool canPlayerMove = true;
    List<PathPoint> PlayersOnPathPointList = new List<PathPoint>();
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
}
