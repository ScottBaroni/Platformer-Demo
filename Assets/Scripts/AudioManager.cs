using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgMugic;
    public AudioSource winMusic;
    public AudioSource sfxPlayer;

    public AudioClip jumpSFX;
    public AudioClip powerupSFX;
    public AudioClip deathSFX;
    public AudioClip collectSFX;

    public void switchMusic()
    {
        bgMugic.Stop();
        winMusic.Play();
    }

    public void playSFX(AudioClip clip)
    {
        sfxPlayer.PlayOneShot(clip);
    }
}
