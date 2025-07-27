using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject MainPanel;
    public GameObject GamePanel;

    public void Game1()
    {
        //logic for 2 players
        GameManager.gm.totalPlayersCanPlay = 2;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameManager.gm.playerHomes[1].SetActive(false);   //red
        GameManager.gm.playerHomes[3].SetActive(false);   //yellow

    }
    public void Game2()
    {
        //logic for 3 players
       GameManager.gm.totalPlayersCanPlay = 3;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameManager.gm.playerHomes[3].SetActive(false);   //yellow
    }
    public void Game3()
    {
        //logic for 4 players
        GameManager.gm.totalPlayersCanPlay = 4;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void Game4()
    {
        //logic for computer player
        GameManager.gm.totalPlayersCanPlay = 1;
        MainPanel.SetActive(false);
        GamePanel.SetActive(true);
        GameManager.gm.playerHomes[1].SetActive(false);   //red
        GameManager.gm.playerHomes[3].SetActive(false);   //yellow
    }
}
