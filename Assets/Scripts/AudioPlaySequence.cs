using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioPlaySequence : GameObjective
{
    public AudioSource myAudioSource;
    public UnityEvent OnAudioStart;

    private bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if(isPlaying && !myAudioSource.isPlaying)
        {
            isPlaying = false;
            SetIsComplete(true);
        }
    }

    public void StartAudio()
    {
        myAudioSource.Play();
        isPlaying = true;
        OnAudioStart.Invoke();
    }
}
