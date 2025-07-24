using UnityEngine;
using System.Collections;
public class PlayerPiece : MonoBehaviour
{
    public bool moveNow;
    public int numberOfStepsToMove;
    public int numberOfStepsAlreadyMove;
    public bool isReady;
    public PathObjectPoint pathParent;
    private void Awake()
    {
        pathParent = FindObjectOfType<PathObjectPoint>();

    }
    public void MakePlayerReadyToMove(PathPoint[] pathParent_)
    {
        isReady = true;
        transform.position = pathParent_[0].transform.position;
        numberOfStepsAlreadyMove = 1;
    }

    public void MovePlayer(PathPoint[] pathParent_)
    {
        StartCoroutine(MoveStep_enum(pathParent_));
    }
    private IEnumerator MoveStep_enum(PathPoint[] pathParent_)
    {
        numberOfStepsToMove = 5;
        for (int i = numberOfStepsAlreadyMove; i < numberOfStepsAlreadyMove + numberOfStepsToMove; i++)
        {
            transform.position = pathParent_[i].transform.position;
            yield return new WaitForSeconds(0.35f);
        }
        numberOfStepsAlreadyMove += numberOfStepsToMove;
    }

}
