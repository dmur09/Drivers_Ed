using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    //public AudioClip GameStartSound;
    public AudioClip GameOverSound;
    public AudioClip BeerSound;
    public AudioClip RedbullSound;
    public AudioClip WeedSound;
    public AudioClip MushroomSound;
    public AudioClip GuardRailSound;
    public AudioClip CoinSound;
    public AudioClip ConstructionSound;
    public AudioClip StopSignSound;
    public AudioClip JailSound;
    public AudioClip LapSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    
    /* public void PlayStart()
    {
        audioSource.PlayOneShot(GameStartSound);
    }*/

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(GameOverSound);
    }

    public void PlayRedbullSound()
    {
        audioSource.PlayOneShot(RedbullSound);
    }

    public void PlayBeerSound()
    {
        audioSource.PlayOneShot(BeerSound);
    }

    public void PlayWeedSound()
    {
        audioSource.PlayOneShot(WeedSound);
    }

    public void PlayMushroomSound()
    {
        audioSource.PlayOneShot(MushroomSound);
    }
    
    public void PlayGuardRailSound()
    {
        audioSource.PlayOneShot(GuardRailSound);
    }
    
    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(CoinSound);
    }
    
    public void PlayConstructionSound()
    {
        audioSource.PlayOneShot(ConstructionSound);
    }
    
    public void PlayStopSignSound()
    {
        audioSource.PlayOneShot(StopSignSound);
    }
    
    public void PlayJailSound()
    {
        audioSource.PlayOneShot(JailSound);
    }
    
    public void PlayLapSound()
    {
        audioSource.PlayOneShot(LapSound);
    }
}
