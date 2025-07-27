using System.Collections;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] Sprite[] numberSprites;
    [SerializeField] SpriteRenderer numberSpriteHolder;
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer rollingDiceAnimation;
    Coroutine generateRandomNumberDice;
   
    private void Start()
    {

    }
    public void OnMouseDown()
    {
        generateRandomNumberDice = StartCoroutine(rollDice());
    }
    IEnumerator rollDice()
    {
        yield return new WaitForEndOfFrame();
        if (GameManager.gm.canDiceRoll)
        {
            GameManager.gm.canDiceRoll = false;
            numberSpriteHolder.gameObject.SetActive(false);
            rollingDiceAnimation.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            numberGot = Random.Range(0, 6);
            numberSpriteHolder.sprite = numberSprites[numberGot];
            numberGot++;
            GameManager.gm.numberOfStepsToMove = numberGot;
            GameManager.gm.rollingDice = this;

            numberSpriteHolder.gameObject.SetActive(true);
            rollingDiceAnimation.gameObject.SetActive(false);

            if(GameManager.gm.numberOfStepsToMove!=6&&outPlayers()==0)
            {
                GameManager.gm.transferDice = true;
                yield return new WaitForSeconds(0.5f);
                GameManager.gm.rollingDiceTrasfer();
            }
           

            if (generateRandomNumberDice != null)
            {
                StopCoroutine(rollDice());
            }
        }     

    }
    public int outPlayers()
    {
        if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[0])
            return GameManager.gm.blueOutPlayer;
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[1])
            return GameManager.gm.redOutPlayer;
        else if (GameManager.gm.rollingDice == GameManager.gm.rollingDiceList[2])
            return GameManager.gm.greenOutPlayer;
        else
            return GameManager.gm.yellowOutPlayer;
    }

}

