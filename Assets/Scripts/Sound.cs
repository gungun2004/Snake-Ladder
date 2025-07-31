using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject mute;
    public GameObject play;

    private void Start()
    {
        UpdateUI();
    }

    public void OnMouseDown()
    {
        // Toggle sound state
        GameManager.gm.sound = !GameManager.gm.sound;

        // Mute or unmute AudioSource
        if (GameManager.gm.ads != null)
        {
            GameManager.gm.ads.mute = !GameManager.gm.sound;

            // Optionally restart audio if turning ON
            if (GameManager.gm.sound && !GameManager.gm.ads.isPlaying)
            {
                GameManager.gm.ads.time = 0f;
                GameManager.gm.ads.Play();
            }
            else if (!GameManager.gm.sound)
            {
                GameManager.gm.ads.Pause();
            }
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (GameManager.gm.sound)
        {
            play.SetActive(true);
            mute.SetActive(false);
        }
        else
        {
            play.SetActive(false);
            mute.SetActive(true);
        }
    }
}