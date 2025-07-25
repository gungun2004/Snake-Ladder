using System.Collections;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] Sprite[] numberSprites;
    [SerializeField] SpriteRenderer numberSpriteHolder;
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer rollingDiceAnimation;
    Coroutine generateRandomNumberDice;
    public bool canDiceRoll = true;
    private void Start()
    {
        
    }
    public void OnMouseDown()
    {
        generateRandomNumberDice= StartCoroutine(rollDice());
    }
    IEnumerator rollDice()
    {
        yield return new WaitforEndOfFrame();
     if (canDiceRoll)
        {
            canDiceRoll = false;
                numberSpriteHolder.gameObject.SetActive(false);
                rollingDiceAnimation.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.8f);
                numberGot = Random.Range(0, 6);
                numberSpriteHolder.sprite = numberSprites[numberGot];
                numberGot++;
            GameManager.gm.numberOfStepsToMove = numberGot;

                numberSpriteHolder.gameObject.SetActive(true);
                rollingDiceAnimation.gameObject.SetActive(false);
            }
        canDiceRoll = true;
        if(generateRandomNumberDice!=null)
        {
            StopCoroutine(rollDice());
        }

    }
}

internal class WaitforEndOfFrame
{
    public WaitforEndOfFrame()
    {
    }
}