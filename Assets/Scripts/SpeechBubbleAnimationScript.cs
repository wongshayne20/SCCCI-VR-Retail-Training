using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeechBubbleAnimationScript : MonoBehaviour
{
    public float cycleDuration = 1.0f;
    private float timer = 0.0f;
    public bool isPlaying = false;

    private int currCount = 0;

    public GameObject[] flashingObjs;

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            timer += Time.deltaTime;

            if(timer > cycleDuration)
            {
                timer = 0.0f;

                ++currCount;

                currCount = currCount > flashingObjs.Length ? 0 : currCount;
            }

            for (int i = 0; i < flashingObjs.Length; ++i)
            {
                flashingObjs[i].gameObject.SetActive(i < currCount);
            }

        }
    }

    public void ResetTimer()
    {
        timer = 0.0f;
        currCount = 0;
    }

    public void ToggleAnim(bool toPlay)
    {
        isPlaying = toPlay;
    }
}
