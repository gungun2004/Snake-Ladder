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
    public PathPoint priviousPathPoint;
    public PathPoint currentPathPoint;
    public bool hasFinished = false;

    [System.Obsolete]
    private void Awake()
    {
        pathParent = FindObjectOfType<PathObjectPoint>();
    }

    public void MakePlayerReadyToMove(PathPoint[] pathParent_)
    {
        isReady = true;
        transform.position = pathParent_[0].transform.position;
        transform.localScale = Vector3.one; // 🔧 Reset scale when spawning

        numberOfStepsAlreadyMove = 1;
        GameManager.gm.numberOfStepsToMove = 0;

        priviousPathPoint = pathParent_[0];
        currentPathPoint = pathParent_[0];
        currentPathPoint.AddPlayerPiece(this);
        GameManager.gm.AddPathPoint(currentPathPoint);
        GameManager.gm.rollingDiceTrasfer();
    }

    public void MovePlayer(PathPoint[] pathParent_)
    {
        playerMovement = StartCoroutine(MoveStep_enum(pathParent_));
    }

    private IEnumerator MoveStep_enum(PathPoint[] pathParent_)
    {
        yield return new WaitForSeconds(0.25f);
        numberOfStepsToMove = GameManager.gm.numberOfStepsToMove;

        int targetStep = numberOfStepsAlreadyMove + numberOfStepsToMove;
        if (targetStep > pathParent_.Length)
        {
            targetStep = pathParent_.Length;
        }

        for (int i = numberOfStepsAlreadyMove; i < targetStep; i++)
        {
            if (isPathPointAvailableToMove(numberOfStepsToMove, numberOfStepsAlreadyMove, pathParent_))
            {
                currentPathPoint.RescaleandRepositioningAllPlayerPiece();
                transform.position = pathParent_[i].transform.position;
                transform.localScale = Vector3.one; // 🔧 Reset scale after movement

                if (GameManager.gm.sound)
                {
                    GameManager.gm.ads.Play();
                }

                yield return new WaitForSeconds(0.35f);
            }
        }

        if (isPathPointAvailableToMove(numberOfStepsToMove, numberOfStepsAlreadyMove, pathParent_))
        {
            numberOfStepsAlreadyMove = targetStep;

            GameManager.gm.RemovePathPoint(priviousPathPoint);
            priviousPathPoint.RemovePlayerPiece(this);

            currentPathPoint = pathParent_[numberOfStepsAlreadyMove - 1];
            if (currentPathPoint.name == "ComanPathPoint")
            {
                hasFinished = true;
            }

            bool transfer = currentPathPoint.AddPlayerPiece(this);
            currentPathPoint.RescaleandRepositioningAllPlayerPiece();
            transform.localScale = Vector3.one; // 🔧 Ensure scale stays correct here too

            GameManager.gm.AddPathPoint(currentPathPoint);
            priviousPathPoint = currentPathPoint;

            if (numberOfStepsToMove != 6 && transfer)
            {
                GameManager.gm.transferDice = true;
            }

            GameManager.gm.numberOfStepsToMove = 0;
        }

        GameManager.gm.canPlayerMove = true;
        GameManager.gm.rollingDiceTrasfer();

        if (playerMovement != null)
        {
            StopCoroutine("MoveStep_enum");
        }
    }

    public bool isPathPointAvailableToMove(int numberOfStepsToMove, int numberOfStepsAlreadyMove, PathPoint[] pathParent_)
    {
        if (numberOfStepsToMove == 0)
        {
            return false;
        }

        int leftNumberOfPath = pathParent_.Length - numberOfStepsAlreadyMove;
        return leftNumberOfPath >= numberOfStepsToMove;
    }
}