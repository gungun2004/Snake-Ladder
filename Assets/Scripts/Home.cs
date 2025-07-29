using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject mainPanel;

    public void OnMouseDown()
    {
        mainPanel.SetActive(true);
        gamePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}