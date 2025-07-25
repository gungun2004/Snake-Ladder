using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int numberOfStepsToMove;
    public RollingDice rollingDice;
    public bool canPlayerMove = true;
    private void Awake()
    {
        gm = this;
    }
}
