using UnityEngine;
using System.Collections;
public class PlayerPiece : MonoBehaviour
{

    public bool moveNow;
    public int numberOfStepsToMove;
    public int numberOfStepsAlreadyMove;
    public bool isReady;
    public PathObjectPoint pathParent;
    Coroutine playerMovement;

    [System.Obsolete]
    private void Awake()
    {
        pathParent = FindObjectOfType<PathObjectPoint>();

    }
    public void MakePlayerReadyToMove( PathPoint[] pathParent_)
    {
        isReady = true;
        transform.position = pathParent_[0].transform.position;
        numberOfStepsAlreadyMove = 1;
    }

    public void MovePlayer(PathPoint[] pathParent_)
    {
       playerMovement= StartCoroutine(MoveStep_enum(pathParent_));
    }
    private IEnumerator MoveStep_enum(PathPoint[] pathParent_)
    {
        numberOfStepsToMove = GameManager.gm.numberOfStepsToMove;

        int targetStep = numberOfStepsAlreadyMove + numberOfStepsToMove;
        if (targetStep > pathParent_.Length)
        {
            targetStep = pathParent_.Length;
        }

        for (int i = numberOfStepsAlreadyMove; i < targetStep; i++)
        {
            transform.position = pathParent_[i].transform.position;
            yield return new WaitForSeconds(0.35f);
        }

        numberOfStepsAlreadyMove = targetStep;
        GameManager.gm.numberOfStepsToMove = 0;
        GameManager.gm.canPlayerMove = true;

        if(playerMovement !=null)
        {
            StopCoroutine("MoveStep_enum");
        }

    }


}
