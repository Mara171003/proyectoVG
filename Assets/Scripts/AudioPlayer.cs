using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource _soundPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playSound(AudioClip sample)
    {
        _soundPlayer.PlayOneShot(sample);
    }
}
