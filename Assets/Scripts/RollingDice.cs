using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class RollingDice : MonoBehaviour
{
    [SerializeField] Sprite[] numberSprites;
    [SerializeField] SpriteRenderer numberSpriteHolder;
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer rollingDiceAnimation;
    Coroutine generateRandomNumberDice;
    int outPlayer;
    List<PlayerPiece> playerPieces;
    PathPoint[] currentPathPoint;
    public PlayerPiece currentPlayerPiece;
    public Dice diceSound;

    public void OnMouseDown()
    {
        generateRandomNumberDice = StartCoroutine(rollDice());
    }

    public void MouseRole()
    {
        generateRandomNumberDice = StartCoroutine(rollDice());
    }
    IEnumerator rollDice()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.gm.canDiceRoll)
        {
            GameManager.gm.canDiceRoll = false;
            if (GameManager.gm.sound) { diceSound.playSound(); }
            numberSpriteHolder.gameObject.SetActive(false);
            rollingDiceAnimation.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            int maxnum = 6;
            if (GameManager.gm.totalSix == 2)
            {
                maxnum = 5;
                GameManager.gm.totalSix = 0;
            }

            numberGot = Random.Range(0, maxnum);
            if (numberGot == 5)
            {
                GameManager.gm.totalSix += 1;
            }


            numberSpriteHolder.sprite = numberSprites[numberGot];
            numberGot++;
            GameManager.gm.numberOfStepsToMove = numberGot;
            GameManager.gm.rollingDice = this;

            numberSpriteHolder.gameObject.SetActive(true);
            rollingDiceAnimation.gameObject.SetActive(false);
            outPlayers();

            if (playerCanMove())
            {
                if (outPlayer == 0)
                {
                    ReadyToMove(0);

                }
                else
                {
                    if (GameManager.gm.totalPlayersCanPlay == 1 && outPlayer < 4 && GameManager.gm.numberOfStepsToMove == 6)
                    {
                        robotOut();

                    }
                    else
                    {
                        currentPlayerPiece.MovePlayer(currentPathPoint);
                    }

                }
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                CheckIfAnyValidMove();  // 🔁 new behavior
            }



            if (generateRandomNumberDice != null)
            {
                StopCoroutine(rollDice());
            }
        }

    }
    public void outPlayers()
    {
        if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[0])
        {
            playerPieces = GameManager.gm.bluePlayerPieces;
            currentPathPoint = playerPieces[0].pathParent.BluePathPoint;
            outPlayer = GameManager.gm.blueOutPlayer;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[1])
        {
            playerPieces = GameManager.gm.redPlayerPieces;
            currentPathPoint = playerPieces[0].pathParent.RedPathPoint;
            outPlayer = GameManager.gm.redOutPlayer;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[2])
        {
            playerPieces = GameManager.gm.greenPlayerPieces;
            currentPathPoint = playerPieces[0].pathParent.GreenPathPoint;
            outPlayer = GameManager.gm.greenOutPlayer;
        }
        else
        {
            playerPieces = GameManager.gm.yellowPlayerPieces;
            currentPathPoint = playerPieces[0].pathParent.YellowPathPoint;
            outPlayer = GameManager.gm.yellowOutPlayer;
        }
    }

    public bool playerCanMove()
    {
        if (GameManager.gm.totalPlayersCanPlay == 1)
        {
            if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[2])
            {
                if (outPlayer > 0)
                {
                    for (int i = 0; i < playerPieces.Count; i++)
                    {
                        if (playerPieces[i].isReady)
                        {
                            if (playerPieces[i].isPathPointAvailableToMove(GameManager.gm.numberOfStepsToMove, playerPieces[i].numberOfStepsAlreadyMove, currentPathPoint))
                            {
                                currentPlayerPiece = playerPieces[i];
                                return true;
                            }
                        }
                    }

                }
            }
        }
        if (outPlayer == 1 && GameManager.gm.numberOfStepsToMove != 6)
        {
            for (int i = 0; i < playerPieces.Count; i++)
            {
                if (playerPieces[i].isReady)
                {
                    if (playerPieces[i].isPathPointAvailableToMove(GameManager.gm.numberOfStepsToMove, playerPieces[i].numberOfStepsAlreadyMove, currentPathPoint))
                    {
                        currentPlayerPiece = playerPieces[i];
                        return true;
                    }
                }
            }
        }
        else if (outPlayer == 0 && GameManager.gm.numberOfStepsToMove == 6)
        {
            return true;
        }
        return false;
    }

    void ReadyToMove(int pos)
    {

        if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[0])
        {
            GameManager.gm.blueOutPlayer += 1;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[1])
        {
            GameManager.gm.redOutPlayer += 1;
        }
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[2])
        {
            GameManager.gm.greenOutPlayer += 1;
        }
        else
        {
            GameManager.gm.yellowOutPlayer += 1;
        }
        playerPieces[pos].MakePlayerReadyToMove(currentPathPoint);
    }
    void robotOut()
    {
        for (int i = 0; i < playerPieces.Count; i++)
        {
            if (!playerPieces[i].isReady)
            {
                ReadyToMove(i);
                return;
            }
        }
    }
    void CheckIfAnyValidMove()
    {
        bool canAnyPawnMove = false;

        foreach (PlayerPiece pawn in playerPieces)
        {
            if (pawn.isReady)
            {
                // Check if the pawn has enough space to move
                if (pawn.isPathPointAvailableToMove(GameManager.gm.numberOfStepsToMove, pawn.numberOfStepsAlreadyMove, currentPathPoint))
                {
                    canAnyPawnMove = true;
                    break;
                }
            }
            else
            {
                // Only one pawn out, and it's not a 6 — can't bring new pawn
                if (GameManager.gm.numberOfStepsToMove == 6)
                {
                    canAnyPawnMove = true;
                    break;
                }
            }
        }

        if (!canAnyPawnMove)
        {
            Debug.Log("❌ No valid moves — transferring turn.");
            GameManager.gm.transferDice = true;
            GameManager.gm.rollingDiceTrasfer();
        }
    }

}