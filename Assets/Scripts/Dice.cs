using UnityEngine;

public class Dice : MonoBehaviour
{
    AudioSource ads;
    private void Start()
    {
        ads = GetComponent<AudioSource>();

    }
    public void playSound()
    {
        ads.Play();
    }

}
