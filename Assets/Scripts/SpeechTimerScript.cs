using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeechTimerScript : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip micClip;

    public float loudnessSensitivity = 100.0f;
    public float minimumThreshold = 0.8f;
    public float speechDuration = 5.0f;

    private bool isRecording = false;

    private bool isTiming = false;

    private float timer;

    public UnityEvent onRecordBegin;
    public UnityEvent onTimerBegin;
    public UnityEvent onTimerEnd;

    public AudioSource DebugAudSrc;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isRecording)
        {
            TimeSpeech();
        }

    }

    public void StartMicrophone()
    {
        Debug.Log("Start recording with " + Microphone.devices[0]);
        
        //foreach(var curr in Microphone.devices)
        //{
        //    Debug.Log("Microphone is: " + curr);
        //}
        
        isRecording = true;
        timer = 0.0f;
        onRecordBegin.Invoke();
        micClip = Microphone.Start(Microphone.devices[0], true, 20, AudioSettings.outputSampleRate);
    }

    public void StopMicrophone()
    {
        Debug.Log("Stop recording with " + Microphone.devices[0]);

        isRecording = false;
        isTiming = false;

        onTimerEnd.Invoke();

        Microphone.End(Microphone.devices[0]);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), micClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
            return 0;


        float[] waveData = new float[sampleWindow];

        clip.GetData(waveData, startPosition);

        //Compute Loudness
        float sumLoudness = 0.0f;

        foreach(var curr in waveData)
            sumLoudness += Mathf.Abs(curr);

        return sumLoudness / sampleWindow;

    }

    public void TimeSpeech()
    {
        if(!isTiming && (GetLoudnessFromMicrophone() * loudnessSensitivity) > minimumThreshold)
        {
            isTiming = true;
            onTimerBegin.Invoke();
        }

        if(isTiming)
        {
            timer += Time.deltaTime;

            if(timer > speechDuration)
            {
                StopMicrophone();
            }
        }
    }

    public void PlaybackAudClip()
    {
        DebugAudSrc.PlayOneShot(micClip);
    }
}
