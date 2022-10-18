using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioSource music;
    public float timer;

    void Start()
    {
        
        music = GetComponent<AudioSource>();

        music.mute = music.mute;

        Invoke("UnmuteAudio", timer);
    }
    void UnmuteAudio()
    {
        music.mute = !music.mute;
    }
}
