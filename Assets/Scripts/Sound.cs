using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject mute;
    public GameObject play;
    public void OnMouseDown()
    {
        if(GameManager.gm.ads)
        {
            GameManager.gm.sound = false;       //for pawn and dice sound
            play.SetActive(false);
            mute.SetActive(true);

        }
        else
        {
            GameManager.gm.sound = true;
            play.SetActive(true);
            mute.SetActive(false);
        }
    }
}
