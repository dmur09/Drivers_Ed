using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip HitGuardrailSound;
    public static Sounds Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        Instance = this;
    }

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    
    public void PlayHitGaurdrailSound()
    {
        audioSource.PlayOneShot(HitGuardrailSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
