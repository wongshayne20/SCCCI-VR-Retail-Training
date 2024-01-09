using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DelayScript : MonoBehaviour
{
    public float delayDuration = 5.0f;
    private float timer = 0.0f;

    private bool isTiming = false;

    public UnityEvent OnDelayComplete;

    // Update is called once per frame
    void Update()
    {
        if(isTiming)
        {
            timer += Time.deltaTime;

            if (timer > delayDuration)
            {
                StopTimer();
                OnDelayComplete.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
        timer = 0.0f;
    }
}
